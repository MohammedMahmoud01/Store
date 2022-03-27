using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class UserModel
    {
        [Required(ErrorMessage ="You Must Enter Your Email")]
        //[RegularExpression(@"/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You Must Enter Your FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You Must Enter Your LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You Must Enter Your Password")]
        [MinLength(8 , ErrorMessage ="Your Password must be more than 8 character")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

    }
}
