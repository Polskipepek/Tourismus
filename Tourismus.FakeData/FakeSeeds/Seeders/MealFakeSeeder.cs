using Microsoft.EntityFrameworkCore;
using Tourismus.FakeData.Factories;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.FakeSeeds.Seeders {
    class MealFakeSeeder : FakeSeederBase<Meal> {
        public MealFakeSeeder(DbSet<Meal> dbSet) : base(dbSet) { }

        protected override void Seed() {
            for (int i = 0; i < 5; i++) {
                dbSet.Add(MealFactory.Create());
            }
        }
    }
}
