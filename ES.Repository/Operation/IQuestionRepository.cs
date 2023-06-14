using ES.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Repository.Operation
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<QuestionMaster>> GetAllQuestionsAsync();
        Task<QuestionMaster> GetQuestionByIdAsync(int id);
        Task<int> CreateQuestionAsync(QuestionMaster question);
        Task UpdateQuestionAsync(QuestionMaster question);
        Task DeleteQuestionAsync(int id); 
        Task AddOptionAsync(OptionMaster option);
        Task<OptionMaster> GetOptionByIdAsync(int id);

    }
}
