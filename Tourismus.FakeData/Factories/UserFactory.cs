using Helpers.HashHelpers;
using System;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.Factories {
    public class UserFactory {

        public static User Create(string password = null) {
            var now = DateTime.Now;
            var salt = Faker.Generators.Strings.GenerateAlphaNumericString(15, 15);

            return new() {
                Email = Faker.Internet.Email(),
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                Hash = HashHelper.CreateSha256(password ?? Faker.Generators.Strings.GenerateAlphaNumericString(10, 15), salt),
                Salt = salt,
                IsAdmin = false,
                TelephoneNumber = Faker.Phone.Number(),
                AccountCreationDate = now.AddHours(-Faker.RandomNumber.Next(1, 1000)),
                LastSuccessfullyLogin = DateTime.Now.AddHours(-Faker.RandomNumber.Next(1, 100)),
                LastUnsuccessfullyLoginAttempt = now.AddHours(-Faker.RandomNumber.Next(1, 50)),
            };
        }
    }
}
