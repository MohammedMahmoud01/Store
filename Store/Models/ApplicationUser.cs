using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage ="You Must Enter Your First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You Must Enter Your Last Name")]
        public string LastName { get; set; }

        //public override string Email { get => base.Email; set => base.Email = value; }

    }
}
