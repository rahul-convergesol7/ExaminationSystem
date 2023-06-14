using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entity
{
    public class UserSignUp
    {

        [Key]
        public  int UserId { get; set; }

        [Required(ErrorMessage = "FirstName Is Required")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "LastName Is Required")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Is Required")]

        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber Is Required")]

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Gender Is Required")]
        public Gender Genders { get; set; }

        [Required(ErrorMessage ="Password Is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Is Required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        public enum Gender
        {
            Male,
            Female,
            Others,
        }
        

    }
}
