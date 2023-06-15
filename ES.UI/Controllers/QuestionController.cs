using ES.Domain.Entity;
using ES.Repository.Operation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ES.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]    
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet("{questionId}")]

        public ActionResult<QuestionMaster> GetAll(int questionId)
        {
            var question = _questionRepository.GetQuestion(questionId);
            if(question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost]
        public ActionResult<QuestionMaster> AddQuestion(QuestionMaster questionMaster)
        {
            _questionRepository.AddQuestion(questionMaster);
            return CreatedAtAction(nameof(_questionRepository.GetQuestion) ,new {questionId = questionMaster.Id});
        }

        [HttpPut("{questionId}")]
        public IActionResult UpdateQuestion(int questionId, QuestionMaster questionMaster) {
        
            var existingQuestion = _questionRepository.GetQuestion(questionId);
            if(existingQuestion == null)
            {
                return NotFound();
            }
            existingQuestion.Text = questionMaster.Text;
            existingQuestion.CorrectOption = questionMaster.CorrectOption;
            existingQuestion.Options = questionMaster.Options;
            _questionRepository.UpdateQuestion(existingQuestion);
            return NoContent();
        }

        // DELETE api/questions/{questionId}
        [HttpDelete("{questionId}")]
        public IActionResult DeleteQuestion(int questionId)
        {
            var existingQuestion = _questionRepository.GetQuestion(questionId);
            if (existingQuestion == null)
            {
                return NotFound();
            }

            _questionRepository.DeleteQuestion(questionId);
            return NoContent();
        }

    }
}