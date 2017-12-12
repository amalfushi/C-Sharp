using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
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