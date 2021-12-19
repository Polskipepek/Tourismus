using System;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.Factories {
    public class HotelFactory {
        public static Hotel Create() {
            return new() {
                Name = Faker.Company.Name(),
                Star = Faker.Generators.Numbers.Int(1, 5),
                PhotosPaths = "",
                Description = Faker.Lorem.Sentence(2).ToString(),
            };
        }
    }
}
