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
        // CRUD operations for OptionMaster
        OptionMaster GetOption(int optionId);
        void AddOption(OptionMaster option);
        void UpdateOption(OptionMaster option);
        void DeleteOption(int optionId);

        // CRUD operations for QuestionMaster
        QuestionMaster GetQuestion(int questionId);
        void AddQuestion(QuestionMaster question);
        void UpdateQuestion(QuestionMaster question);
        void DeleteQuestion(int questionId);

        void GetAllQuestion();
    }
}
