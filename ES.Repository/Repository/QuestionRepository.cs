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

        public async Task AddOptionAsync(OptionMaster option)
        {
            _examinationDbContext.OptionMasters.Add(option);
            await _examinationDbContext.SaveChangesAsync();
        }

        public async Task<int> CreateQuestionAsync(QuestionMaster question)
        {
            _examinationDbContext.QuestionMasters.Add(question);
            await _examinationDbContext.SaveChangesAsync();
            return question.Id;
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var question = await _examinationDbContext.QuestionMasters.FindAsync(id);
            if (question != null)
            {
                _examinationDbContext.QuestionMasters.Remove(question);
                await _examinationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<QuestionMaster>> GetAllQuestionsAsync()
        {
            return await _examinationDbContext.QuestionMasters.ToListAsync();
        }

        public async Task<OptionMaster> GetOptionByIdAsync(int id)
        {
            return await _examinationDbContext.OptionMasters.FindAsync(id);
        }

        public async Task<QuestionMaster> GetQuestionByIdAsync(int id)
        {
            return await _examinationDbContext.QuestionMasters.FindAsync(id);
        }

      
        public async Task UpdateQuestionAsync(QuestionMaster question)
        {


            _examinationDbContext.Entry(question).State = EntityState.Modified;
            await _examinationDbContext.SaveChangesAsync();
        }
    }
}
