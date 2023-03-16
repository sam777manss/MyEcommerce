using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEcommerce.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Display(Name = "Mobile Number")]
        //[Required]
        //[RegularExpression(@"^[0-9]{0,10}$", ErrorMessage = "Number are allowed only.")]
        //public string PhoneNumber { get; set; }

        //[Display(Name = "Current Address")]
        //[Required]
        //public string address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        // add validation here for the field which is added
        [Display(Name = "First Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [RegularExpression(@"^[A-Z]+[A-Za-z]{1,}$", ErrorMessage = "First Letter should be capital (e.g. Abc).")]
        public string fname { get; set; }


        [Display(Name = "Last Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        [RegularExpression(@"^[A-Z]+[A-Za-z]{1,}$", ErrorMessage = "First Letter should be capital (e.g. Abc).")]
        public string lname { get; set; }

        [Display(Name = "Enter Number")]
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string Pnumber { get; set; }
        //[Display(Name = "Date of Birth")]
        //[Required]
        //[ValidateBirthDate]
        //public DateTime dob { get; set; }

        //[Display(Name = "Gender")]
        //[Required]
        //public string gender { get; set; }
        public string UserRoles { get; set; }
    }
    public class ProductAddModel
    {
        [Key]
        public int id { get; set; }
       
        public string name { get; set; }
       
        public string prize { get; set; }
        
        public string availability { get; set; }
        
        public string description { get; set; }
       
        public string details { get; set; }
       
        public string flag { get; set; }
        public string imageUrl { get; set; }
        [Display(Name = "Enter Shipping Address")]
        [Required]
        public string address { get; set; }
        public string categories { get; set; }
    }
    public class ProductAddModel2
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Enter Prize")]
        public string prize { get; set; }
        [Required]
        [Display(Name = "Enter Availability")]
        public string availability { get; set; }
        [Required]
        [Display(Name = "Enter Description")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Enter Details")]
        public string details { get; set; }
        [Required]
        [Display(Name = "Enter Flag")]
        public string flag { get; set; }
        public string imageUrl { get; set; }
        
        public string categories { get; set; }
    }
    public class UserCardModel
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string totalprize { get; set; }
        public string flag { get; set; }
        public string imgcardUrl { get; set; }
        public string description { get; set; }
        public string userId { get; set; }
        public string details { get; set; }
        public string address { get; set; }
    }
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    //public class ValidateBirthDate : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        DateTime _birthDate = Convert.ToDateTime(value);

    //        var today = DateTime.Today;

    //        var date = _birthDate.AddYears(13);

    //        if (_birthDate > today || today < date)

    //            return new ValidationResult("Enter valid Birth Date (Age Limit: 13 year)");
    //        else

    //            return ValidationResult.Success;
    //    }
    //}
}
