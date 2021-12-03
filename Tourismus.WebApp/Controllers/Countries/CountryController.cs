using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels.Dtos.ControllerBase;
using Tourismus.WebApp.ReadModels.Dtos.List;

namespace Tourismus.WebApp.Controllers.Countries {
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase {

        public CountryController(TourismusDbContext context) {
            this.context = context;
        }

        private readonly TourismusDbContext context;

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> AddNewCountryAction([FromBody][Required] AddNewCountryParameters parameters) {
            if (parameters == null) {
                throw new System.Exception("Add new country without parameters?!?");
            }

            Country country = new() {
                Name = parameters.Name,
            };

            await context.Countries.AddAsync(country);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Country_Dto[]> GetCountries() {
            return Country_DtoFactory.BuildDtos(context, context.Countries);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult RemoveCountry([FromBody][Required] int cityId) {

            var country = context.Countries.FirstOrDefault(c => c.Id == cityId);
            if (country == null) {
                throw new System.Exception("Trying to remove country that doesnt exist.");
            }

            context.Countries.Remove(country);
            context.SaveChanges();
            return Ok();
        }
    }
}
