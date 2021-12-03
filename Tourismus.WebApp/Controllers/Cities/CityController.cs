using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Tourismus.Model.Models;
using Tourismus.WebApp.Controllers.Offers;
using Tourismus.WebApp.ReadModels.Dtos.ControllerBase;
using Tourismus.WebApp.ReadModels.Dtos.List;

namespace Tourismus.WebApp.Controllers.Cities {
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase {

        public CityController(TourismusDbContext context) {
            this.context = context;
        }

        private readonly TourismusDbContext context;

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddNewCityAction([FromBody][Required] AddNewCityParameters parameters) {
            if (parameters == null) {
                throw new System.Exception("Add new city without parameters?!?");
            }

            City city = new() {
                Name = parameters.Name,
                CountryId = parameters.CountryId,
                IsAirport = parameters.IsAirport,
            };

            context.Cities.Add(city);
            context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<City_Dto[]> GetCities() {
            return City_DtoFactory.BuildDtos(context, context.Cities);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult RemoveCity([FromBody][Required] int cityId) {

            var city = context.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null) {
                throw new System.Exception("Trying to remove city that doesnt exist.");
            }

            context.Cities.Remove(city);
            context.SaveChanges();
            return Ok();
        }
    }
}
