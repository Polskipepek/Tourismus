using System;
using System.Linq;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.Factories {
    public class CountryFactory {
        public static Country Create() {
            return new() {
                Cities = Enumerable.Range(0, Faker.RandomNumber.Next(10)).Select(n=>CityFactory.Create()).ToList(),
                Name = Faker.Country.Name(),
            };
        }
    }
}
