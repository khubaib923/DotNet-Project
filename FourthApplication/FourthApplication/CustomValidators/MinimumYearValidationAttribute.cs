using System.ComponentModel.DataAnnotations;

namespace FourthApplication.CustomValidators
{
    public class MinimumYearValidationAttribute : ValidationAttribute
    {
        public int _MinimumYear { get; set; } = 2000;
        public string ErrorMsg = "Year should be less than {0}";
        public MinimumYearValidationAttribute() { }
        public MinimumYearValidationAttribute(int minimumYear)
        {

            _MinimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dateTime = (DateTime)value;
                if (dateTime.Year >= _MinimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage??ErrorMsg,_MinimumYear));
                }
                else
                {
                    return ValidationResult.Success;
                }

            }
            else
            {
                return null;
            }
        }
    }
}
