using Helpers.HashHelpers;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tourismus.Model.Models;
using Tourismus.WebApp.Controllers.Users.Parameters;

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
        public async Task<ActionResult> AddNewUserAction([FromBody][Required] AddNewUserParameters parameters) {
            if (parameters == null || parameters.Password.Length < 8 || parameters.Email.Length < 4) {
                throw new Exception("Wrong parameters");
            }

            if (context.Users.Any(user => user.Email.Equals(parameters.Email))) {
                return Conflict();
            }

            var salt = Faker.Generators.Strings.GenerateAlphaNumericString(25, 30);

            var user = new User {
                AccountCreationDate = DateTime.Now,
                Email = parameters.Email,
                FirstName = parameters.FirstName,
                LastName = parameters.LastName,
                TelephoneNumber = parameters.TelephoneNumber,
            };

            var userCredential = new UserCredential {
                Salt = salt,
                Hash = HashHelper.CreateSha256(parameters.Password, salt),
            };

            try {
                await context.Users.AddAsync(user);
                await context.UserCredentials.AddAsync(userCredential);
                await context.SaveChangesAsync();
            } catch (Exception e) {
                throw new Exception(e.Message);
            }

            return Ok();
        }
    }
}
