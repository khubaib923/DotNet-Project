using EightApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace EightApplication.ViewComponents
{
    [ViewComponent] //same as controller as suffix
    public class GridViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PersonGrid personGrid)
        {
            PersonGrid grid = new PersonGrid()
            {
                GridTitle = "Person List",
                Persons = new List<Person>()
                {
                    new Person() {JobTitle="Manager",PersonName="yasir"},
                    new Person() {JobTitle="Ass.Manager",PersonName="nuhail"},
                    new Person() {JobTitle="Director",PersonName="Qadir"},
                }
            };
            //ViewData["grid"] = grid;
            return View("Sample",personGrid); //if view is not default then give the view name "Sample"
        }
    }
}
