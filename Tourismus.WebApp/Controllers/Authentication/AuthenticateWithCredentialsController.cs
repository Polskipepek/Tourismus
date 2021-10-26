using Helpers.Constants;
using Helpers.ExtensionMethods;
using Helpers.MailHelpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Tourismus.Model.Models;
using Tourismus.WebApp._Infrastructure.Authentication;
using Tourismus.WebApp.Configuration.Modules.Authentication;

namespace Tourismus.WebApp.Controllers.Authentication {
    public class AuthenticateWithCredentialsController : Controller {
        private readonly TourismusDbContext _context;
        private readonly IUserService userService;
        public AuthenticateWithCredentialsController(TourismusDbContext context, IUserService userService) {
            _context = context;
            this.userService = userService;
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Authenticate([FromBody] AuthenticateWithCredentialsParameters action) {
            if (string.IsNullOrEmpty(action.Password) || string.IsNullOrEmpty(action.Mail) || !MailHelper.IsValidEmail(action.Mail))
                return Unauthorized(null);

            var user = await userService.AuthenticateAsync(action.Mail, action.Password);

            if (user != null) {
                SignIn(action.Mail, ref user);
            }
            var wtf = user.WithoutSensitiveDataButToken();
            return Ok(wtf);
        }

        private void SignIn(string mail, ref User user) {
            var token = CreateToken();
            var claimsIdentity = CreateClaimsIdentity(token, mail);

            var taskSignResult = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            taskSignResult.GetAwaiter().GetResult();

            GetCookieValueFromResponse(ConfigureAddAuthenticationExtension.AuthCookieName, out string cookieToken);
            user.Token = cookieToken;
            _context.SaveChanges();
        }

        private static string CreateToken() {
            return Guid.NewGuid().ToString();
        }

        private static ClaimsIdentity CreateClaimsIdentity(string token, string email) {
            var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, email));
            claimsIdentity.AddClaim(new Claim(CookieAuthenticationConst.TokenClaimType, token));

            return claimsIdentity;
        }

        private bool GetCookieValueFromResponse(string cookieName, out string value) {
            value = null;
            foreach (var headers in Response.Headers.Values)
                foreach (var header in headers)
                    if (header.StartsWith($"{cookieName}=")) {
                        var p1 = header.IndexOf('=');
                        var p2 = header.IndexOf(';');
                        value = header.Substring(p1 + 1, p2 - p1 - 1);
                    }
            return false;
        }
    }
}
