using System.ComponentModel.DataAnnotations;

namespace ValidatingForms.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage="First Name is Required")]
        [MinLength(2, ErrorMessage="First name must be at least 2 characters")]
        public string First_Name { get; set; }

        [Required(ErrorMessage="Last Name is Required")]
        [MinLength(2, ErrorMessage="Last name must be at least 3 characters")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage="Age is Required")]
        [Range(18,120, ErrorMessage="Invalid Age")]
        public int Age { get; set; }

        [Required(ErrorMessage="Email is Required")]
        [EmailAddress(ErrorMessage="Invalid Email")]
        public string Email { get; set;}

        [Required(ErrorMessage="Password is Required")]
        [MinLength(8, ErrorMessage="Passwords must be at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage="Password Confirmation is Required")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage="Passwords don't match.")]
        public string C_Password { get; set;}
    }
}