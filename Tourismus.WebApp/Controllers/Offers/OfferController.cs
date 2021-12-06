using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tourismus.Model.Models;

namespace Tourismus.WebApp.Controllers.Offers {
    [Route("api/offers")]
    [ApiController]
    public class OfferController : ControllerBase {

        public OfferController(TourismusDbContext context) {
            this.context = context;
        }

        private readonly TourismusDbContext context;

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> AddNewOfferAction([FromBody][Required] AddNewOfferParameters parameters) {
            if (parameters == null) {
                throw new System.Exception("Add new offer without parameters?!?");
            }

            var hotel = context.Hotels.FirstOrDefault(h => h.Id == parameters.HotelId);
            if (hotel == null) {
                throw new System.Exception("Add new offer without a hotel?!?");
            }

            var city = context.Cities.FirstOrDefault(c => c.Id == parameters.CityId);
            if (city == null) {
                throw new System.Exception("Add new offer without a city?!?");
            }

            Offer offer = new() {
                CityId = parameters.CityId,
                DateFrom = parameters.DateFrom,
                DateTo = parameters.DateTo,
                Description = parameters.Description,
                HotelId = parameters.HotelId,
                MealsId = parameters.MealsId,
                NumberOfPeople = parameters.NumberOfPeople,
                Price = parameters.Price,
            };

            await context.Offers.AddAsync(offer);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
