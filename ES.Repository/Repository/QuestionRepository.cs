using ES.Domain.Entity;
using ES.Domain.Persistence;
using ES.Repository.Operation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Repository.Repository
{

    public class QuestionRepository : IQuestionRepository
    {

        private readonly ExaminationDbContext _examinationDbContext;

        public QuestionRepository(ExaminationDbContext examinationDbContext)
        {
            _examinationDbContext = examinationDbContext;
        }

        public void AddOption(OptionMaster option)
        {
            _examinationDbContext.OptionMasters.Add(option);
            _examinationDbContext.SaveChanges();
        }


        public void DeleteOption(int optionId)
        {
            var option = _examinationDbContext.OptionMasters.Find(optionId);
            if (option != null)
            {
                _examinationDbContext.OptionMasters.Remove(option);
                _examinationDbContext.SaveChanges();
            }
        }

        public OptionMaster GetOption(int optionId)
        {
            return _examinationDbContext.OptionMasters.Find(optionId);
        }

        public void UpdateOption(OptionMaster option)
        {
            _examinationDbContext.Entry(option).State = EntityState.Modified;
            _examinationDbContext.SaveChanges();
        }

        public QuestionMaster GetQuestion(int questionId)
        {
            return _examinationDbContext.QuestionMasters
          .Include(q => q.Options)
          .SingleOrDefault(q => q.Id == questionId);
        }

        public void DeleteQuestion(int questionId)
        {
            var question = _examinationDbContext.QuestionMasters.Find(questionId);
            if (question != null)
            {
                _examinationDbContext.QuestionMasters.Remove(question);
                _examinationDbContext.SaveChanges();
            }
        }

        public void UpdateQuestion(QuestionMaster question)
        {
            _examinationDbContext.Entry(question).State = EntityState.Modified;
            _examinationDbContext.SaveChanges();
        }

        public void AddQuestion(QuestionMaster question)
        {
            _examinationDbContext.QuestionMasters.Add(question);
            _examinationDbContext.SaveChanges();
        }

        public void GetAllQuestion()
        {
            _examinationDbContext.QuestionMasters.ToList();
            _examinationDbContext.SaveChanges();
        }
    }
}
