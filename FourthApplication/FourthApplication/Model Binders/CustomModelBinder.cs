using FourthApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FourthApplication.Model_Binders
{
    public class CustomModelBinder : IModelBinder
    {
        public Task BindModelAsync([FromBody]ModelBindingContext bindingContext)
        {
            Person person=new Person();
            if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
            {
                person.PersonName=bindingContext.ValueProvider.GetValue("FirstName").FirstOrDefault();
            }

            if (bindingContext.ValueProvider.GetValue("LastName").Length > 0)
            {
                person.PersonName+= " " +bindingContext.ValueProvider.GetValue("LastName").FirstOrDefault();
            }
            if (bindingContext.ValueProvider.GetValue("Email").Length > 0)
            {
                person.Email = bindingContext.ValueProvider.GetValue("Email").FirstOrDefault();
            }
            if (bindingContext.ValueProvider.GetValue("Phone").Length > 0)
            {
                person.Phone = bindingContext.ValueProvider.GetValue("Phone").FirstOrDefault();
            }
            if (bindingContext.ValueProvider.GetValue("Password").Length > 0)
            {
                person.Password = bindingContext.ValueProvider.GetValue("Password").FirstOrDefault();
            }
            if (bindingContext.ValueProvider.GetValue("COnfirmPassword").Length > 0)
            {
                person.ConfirmPassword = bindingContext.ValueProvider.GetValue("ConfirmPassword").FirstOrDefault();
            }
            if (bindingContext.ValueProvider.GetValue("Age").Length > 0)
            {
                person.Age = Convert.ToInt32(bindingContext.ValueProvider.GetValue("Age").First());
            }
            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}
