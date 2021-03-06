﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [StringLength(24, MinimumLength = 8)]
        //[Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        public string Password { get; set; }

        /*[Required(ErrorMessage = "Please confirm your password")]
        public string ConfirmPassword { get; set; }
        */

    }
}
