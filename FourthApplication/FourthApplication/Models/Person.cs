using FourthApplication.CustomValidators;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FourthApplication.Models
{
    public class Person:IValidatableObject
    {
        [Required(ErrorMessage = "{0} can't be empty or null")]
        [DisplayName("Person Name")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "{0} length should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z .]*$",ErrorMessage ="{0} should only contain letter spaces and dot")]
        public string? PersonName { get; set; }
        //[EmailAddress(ErrorMessage = "{0} should be a proper valid email")]
        [BindNever]
        public string? Email { get; set; }
        //[StringLength(11, MinimumLength = 11, ErrorMessage = "{0} length should be between {2} and {1} characters long")]
        [Phone(ErrorMessage ="{0} should contain 10 digits")]
        public string? Phone { get; set; }
        [ValidateNever]
        public string? Password { get; set; }
        [Compare("Password",ErrorMessage ="{1} and {0} should be equal")]
        [Display(Name ="Re-enter Password")]
        
        public string? ConfirmPassword { get; set; }
        [Range(0, 100, ErrorMessage = "{0} length should be between {1} and {2} number")]
        public double? Price { get; set; }
        //[MinimumYearValidation(2005,ErrorMessage ="Date of Birth should not be newer than Jan 01,2000")]
        [MinimumYearValidation(2005)]
        public DateTime? DateTime { get; set; }

        public DateTime? FromDate { get; set; }
        [DateRangeValidator("FromDate",ErrorMessage ="FromDate should be older than or equal to the ToDate")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }


        public List<string>? Tags { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"Person name are:{PersonName}, email are {Email},Phone no are {Phone},Password are {Password}, and Price are {Price}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(DateTime.HasValue==false && Age.HasValue == false)
            {
                 yield return new ValidationResult("Either of the date or age must be supplied!",new string[] {nameof(Age),nameof(DateTime)});
                
            }
            
        }
    }
}
