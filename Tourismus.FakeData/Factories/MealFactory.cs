using System;
using System.Linq;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.Factories {
    public class MealFactory {
        public static Meal Create() {
            return new() {
                Name = Faker.Lorem.GetFirstWord(),
            };
        }
    }
}
