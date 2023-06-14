using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entity
{
    public class QuestionMaster
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        
        [Required]
        public int CorrectOption { get; set; }

        public ICollection<OptionMaster> Options { get; set; }
    }
}
