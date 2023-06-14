﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entity
{
    public class UserLogin
    {
        [Required(ErrorMessage ="Email its Required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password its Required")]
        public string Password { get; set; }
    }
}
