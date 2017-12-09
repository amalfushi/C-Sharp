using System.ComponentModel.DataAnnotations;

namespace LoginReg.Models
{
    public class User : BaseEntity
    {
        public int UserID { get; set; }
        
        [Required(ErrorMessage="First Name is Required")]
        [MinLength(2, ErrorMessage="First name must be at least 2 characters")]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Required(ErrorMessage="Last Name is Required")]
        [MinLength(2, ErrorMessage="Last name must be at least 3 characters")]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

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
        [Display(Name = "Confirm Password")]
        public string C_Password { get; set;}
    }

    public class LoginUser : BaseEntity
    {
        [Required(ErrorMessage="Email is Required")]
        [EmailAddress(ErrorMessage="Invalid Email")]
        public string Email { get; set;}

        [Required(ErrorMessage="Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class HomePageUsers
    {
        public User Register { get; set; }
        public LoginUser Login { get; set; }
    }
}