using Api.Model.Database;
using Helpers.HashHelpers;

namespace Tourismus.FakeData.Factories {
    public class UserCredentialFactory {
        public static UserCredential Create(string password = null) {

            var salt = Faker.Generators.Strings.GenerateAlphaNumericString(15, 15);

            return new() {
                Hash = HashHelper.CreateSha256(password ?? Faker.Generators.Strings.GenerateAlphaNumericString(10, 15), salt),
                Salt = salt,
            };
        }
    }
}
