


using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Tourismus.Model.Models;

namespace Tourismus.WebApp.Controllers.Hotels {
    [Route("api/hotels")]
    [ApiController]
    public class HotelController : ControllerBase {

        public HotelController(TourismusDbContext context) {
            this.context = context;
        }

        private readonly TourismusDbContext context;

        [HttpPost]
        [Route("[action]")]
        [SwaggerResponse(HttpStatusCode.OK, null)]
        public async Task<ActionResult> AddNewHotelAction([FromBody][Required] AddNewHotelParameters parameters) {
            if (parameters == null) {
                throw new System.Exception("Add new hotel without parameters?!?");
            }

            Hotel hotel = new() {
                Name = parameters.Name,
                CityId = parameters.CityId,
                Description = parameters.Description,
                Star = parameters.Star,
                PhotosPaths = parameters.PhotosPaths,
            };

            await context.Hotels.AddAsync(hotel);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
