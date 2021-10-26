using Helpers.HashHelpers;
using System.Linq;
using System.Threading.Tasks;
using Tourismus.Model.Models;

namespace Tourismus.WebApp._Infrastructure.Authentication {
    class UserService : IUserService {
        private readonly TourismusDbContext context;

        public UserService(TourismusDbContext context) {
            this.context = context;
        }

        public async Task<User> AuthenticateAsync(string mail, string password) {
            var userCredential = await TryGetUserCredentials(mail);
            if (userCredential != null) {
                if (HashHelper.VerifyHash(password + userCredential.Salt, userCredential.Hash) == false) {
                    return null;
                }
                var user = context.Users.FirstOrDefault(u => u.Id == userCredential.Id);
                if (user != null) {
                    user.Token = Faker.Generators.Strings.GenerateAlphaNumericString(16, 16);
                    context.Users.Update(user);
                    return user;
                }
            }
            return null;
        }

        public User Authorize() {
            throw new System.NotImplementedException();
        }

        private async Task<UserCredential> TryGetUserCredentials(string mail) {
            var user = context.Users.FirstOrDefault(u => u.Email == mail);

            return user != null ? context.UserCredentials.First(u => u.UserId == user.Id) : null;
        }
    }
}
