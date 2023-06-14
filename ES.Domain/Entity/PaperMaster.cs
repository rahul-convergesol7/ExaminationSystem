using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entity
{
    public class PaperMaster
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public int DurationInMinutes { get; set; }
        public ICollection<QuestionMaster> Questions { get; set; }
    }
}
