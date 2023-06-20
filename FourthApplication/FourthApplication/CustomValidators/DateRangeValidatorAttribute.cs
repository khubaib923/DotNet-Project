using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FourthApplication.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }
        public DateRangeValidatorAttribute(string otherpropertyname)
        {
            OtherPropertyName = otherpropertyname;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime to_date = (DateTime)value;

                PropertyInfo? propertyInfo = validationContext.ObjectType.GetProperty("FromDate");
                if (propertyInfo != null)
                {
                    DateTime from_date = (DateTime)propertyInfo.GetValue(validationContext.ObjectInstance)!;
                    if (from_date > to_date)
                    {
                        return new ValidationResult(ErrorMessage, new string[] {OtherPropertyName,validationContext.MemberName! });
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                else { return null; }
            }
            else
            {
                return null;
            }
        }
    }
}
