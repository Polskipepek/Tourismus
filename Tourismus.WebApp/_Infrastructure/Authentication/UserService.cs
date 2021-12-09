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

        public User AuthenticateAsync(string mail, string password) {
            var user = TryGetUserCredentials(mail);
            if (user != null) {
                if (HashHelper.VerifyHash(password + user.Salt, user.Hash) == false)
                    return null;

                user.Token = Faker.Generators.Strings.GenerateAlphaNumericString(16, 16);
                context.Users.Update(user);
                return user;

            }
            return null;
        }

        public User Authorize() {
            throw new System.NotImplementedException();
        }

        private User TryGetUserCredentials(string mail) {

            return context.Users.First(u => u.Email == mail);
        }
    }
}
