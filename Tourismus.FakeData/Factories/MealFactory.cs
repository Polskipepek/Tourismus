using Api.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tourismus.FakeData.Factories {
    public class MealFactory {
        private static Random random = new();

        private static readonly string[] _shopCategoriesNames = new string[] {
            "Spożywczy",
            "Budowlany",
            "Rzeźnik",
            "Piekarnia",
            "Agd",
            "Rtv"
        };

        private static readonly List<Meal> _shopCategories = new() {
            new Meal() {
                Name = _shopCategoriesNames[0],
            },
            new Meal() {
                Name = _shopCategoriesNames[1],
            },
            new Meal() {
                Name = _shopCategoriesNames[2],
            },
            new Meal() {
                Name = _shopCategoriesNames[3],
            },
            new Meal() {
                Name = _shopCategoriesNames[4],
            },
            new Meal() {
                Name = _shopCategoriesNames[5],
            },
        };

        public static Meal Create() {
            return _shopCategories.ElementAt(random.Next(0, _shopCategories.Count - 1));
        }
    }
}
