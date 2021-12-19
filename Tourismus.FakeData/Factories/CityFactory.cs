using System;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.Factories {
    public class CityFactory {
        public static City Create() {
            return new() {
                IsAirport = Faker.Boolean.Random(),
                Name = Faker.Address.City(),
            };
        }
    }
}
