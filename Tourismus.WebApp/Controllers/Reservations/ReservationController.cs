using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Tourismus.Model.Models;

namespace Tourismus.WebApp.Controllers.Shops {
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : Controller {
        public ReservationController(TourismusDbContext context) {
            this.context = context;
        }

        private readonly TourismusDbContext context;

        [HttpPost]
        [Route("[action]")]
        [SwaggerResponse(HttpStatusCode.OK, null)]
        public async Task<ActionResult> AddNewShopAction([FromBody][Required] int action) {
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        [SwaggerResponse(HttpStatusCode.OK, null)]
        public async Task<ActionResult> EditShopAction([FromBody][Required] int action) {
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        [SwaggerResponse(HttpStatusCode.OK, null)]
        public async Task<ActionResult> RemoveShopAction([FromBody][Required] int action) {
            return Ok();
        }
    }
}
