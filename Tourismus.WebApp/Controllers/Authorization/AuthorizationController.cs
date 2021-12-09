using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tourismus.Model.Models;
using Tourismus.WebApp._Infrastructure.Authentication;

namespace Tourismus.WebApp.Controllers.Authentication {
    public class AuthorizationController : Controller {
        private readonly TourismusDbContext _context;
        private readonly IUserService userService;
        public AuthorizationController(TourismusDbContext context, IUserService userService) {
            _context = context;
            this.userService = userService;
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> Authorize() {
            var user = userService.Authorize();
            return user!=null;
        }
    }
}
