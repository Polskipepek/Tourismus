using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tourismus.FakeData.Factories;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.FakeSeeds.Seeders {
    class MealFakeSeeder : FakeSeederBase<Meal, IEnumerable<Meal>> {
        public MealFakeSeeder(DbSet<Meal> dbSet) : base(dbSet) { }

        public override void Seed() {
            for (int i = 0; i < 5; i++) {
                dbSet.Add(MealFactory.Create());
            }
        }

        public override IEnumerable<Meal> SeedWithResult() {
            for (int i = 0; i < 4; i++) {
                var meal = MealFactory.Create();
                dbSet.Add(meal);
                yield return meal;
            }

        }
    }
}
