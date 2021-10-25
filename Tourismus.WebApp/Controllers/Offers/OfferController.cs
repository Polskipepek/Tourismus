using Api.Model.Database;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace Tourismus.WebApp.Controllers.Products {
    [Route("api/offers")]
    [ApiController]
    public class OfferController : ControllerBase {

        public OfferController(TourismusDbContext context) {
            this.context = context;
        }

        private readonly TourismusDbContext context;

        [HttpPost]
        [Route("[action]")]
        [SwaggerResponse(HttpStatusCode.OK, null)]
        public async Task<ActionResult> AddNewProductAction([FromBody][Required] int action) {
            return Ok();
        }
    }
}
