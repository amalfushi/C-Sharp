using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WeddingPlanner.Models
{
 
    public class RegisterUser: BaseEntity
    {
        private Regex reg;

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        // [RegularExpression()]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string C_Password { get; set; }

        public RegisterUser(){
            reg = new Regex(@"!\s{2,}");
        }
    }
}