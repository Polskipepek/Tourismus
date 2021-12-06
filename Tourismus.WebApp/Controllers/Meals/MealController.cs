using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Tourismus.Model.Models;
using Tourismus.WebApp.Controllers.Offers;
using Tourismus.WebApp.ReadModels.Dtos.ControllerBase;
using Tourismus.WebApp.ReadModels.Dtos.List;

namespace Tourismus.WebApp.Controllers.Cities {
    [Route("api/meals")]
    [ApiController]
    public class MealController : ControllerBase {

        public MealController(TourismusDbContext context) {
            this.context = context;
        }

        private readonly TourismusDbContext context;

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddNewMealAction([FromBody][Required] AddNewMealParameters parameters) {
            if (parameters == null) {
                throw new System.Exception("Add new meal without parameters?!?");
            }

            Meal meal = new() {
                Name = parameters.Name,
            };

            context.Meals.Add(meal);
            context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Meal_Dto[]> GetMeals() {
            return Meal_DtoFactory.BuildDtos(context, context.Meals);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult RemoveMeal([FromBody][Required] int mealId) {

            var meal = context.Meals.FirstOrDefault(c => c.Id == mealId);
            if (meal == null) {
                throw new System.Exception("Trying to remove meal that doesnt exist.");
            }

            context.Meals.Remove(meal);
            context.SaveChanges();
            return Ok();
        }
    }
}
