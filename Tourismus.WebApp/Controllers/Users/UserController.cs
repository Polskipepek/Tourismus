using Api.Model.Database;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace Tourismus.WebApp.Controllers.Users {
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase {
        public UserController(TourismusDbContext context) {
            this.context = context;
        }

        private readonly TourismusDbContext context;

        [HttpPost]
        [Route("[action]")]
        [SwaggerResponse(HttpStatusCode.OK, null)]
        public async Task<ActionResult> AddNewuserAction([FromBody][Required] int action) {
            return Ok();
        }
    }
}
