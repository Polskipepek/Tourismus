using Helpers.HashHelpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using Tourismus.Model.Models;
using Tourismus.WebApp.Controllers.Users.Parameters;
using Tourismus.WebApp.ReadModels.Dtos.Single;

namespace Tourismus.WebApp.Controllers.Users {
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase {
        public UserController(TourismusDbContext context) {
            this.context = context;
        }

        private readonly TourismusDbContext context;
        readonly long date2000 = 630822816000000000;

        [HttpPost]
        [Route("[action]")]
        [SwaggerResponse(HttpStatusCode.OK, null)]
        public IActionResult AddNewUserAction([FromBody][Required] AddNewUserParameters parameters) {
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
                Salt = salt,
                Hash = HashHelper.CreateSha256(parameters.Password, salt),
                IsAdmin = false,
                LastUnsuccessfullyLoginAttempt = new DateTime(date2000),
                LastSuccessfullyLogin = new DateTime(date2000),
            };

            try {
                context.Users.Add(user);
                context.SaveChanges();
            } catch (Exception e) {
                throw new Exception(e.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        [SwaggerResponse(HttpStatusCode.OK, null)]
        public new ActionResult SignOut() {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<User_Dto> GetUserData(int id) {
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) {
                throw new Exception("user is null");
            }
            return User_DtoFactory.BuildDtos(context, user);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult UpdateUser([FromBody]EditUserParameters parameters) {
            var user = context.Users.FirstOrDefault(u => u.Id == parameters.Id);
            if (user == null) {
                throw new Exception("user is null");
            }
            var salt = Faker.Generators.Strings.GenerateAlphaNumericString(25, 30);

            user.FirstName = parameters.FirstName;
            user.LastName = parameters.LastName;   
            user.Email = parameters.Email;
            user.TelephoneNumber = parameters.TelephoneNumber;
            if (parameters.Password.Length>5) {
                user.Salt = salt;
                user.Hash = HashHelper.CreateSha256(parameters.Password, salt);
            }
            context.SaveChanges();

            return Ok();
        }
    }
}
