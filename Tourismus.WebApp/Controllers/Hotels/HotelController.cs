


using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels.Dtos.ControllerBase;
using Tourismus.WebApp.ReadModels.Dtos.List;

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

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Hotel_Dto[]> GetHotels() {
            return Hotel_DtoFactory.BuildDtos(context, context.Hotels);
        }
    }
}
