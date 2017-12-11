using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class LoginUser: BaseEntity
    {
        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        // [RegularExpression()]
        public string LogEmail { get; set; }

        [Required]
        [Display(Name = "Password")]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string LogPassword { get; set; }
    }
}