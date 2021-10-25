using Api.Model.Database;
using Microsoft.EntityFrameworkCore;
using Tourismus.FakeData.Factories;

namespace Tourismus.FakeData.FakeSeeds.Seeders {
    class UserFakeSeeder : FakeSeederBase<User> {

        public UserFakeSeeder(DbSet<User> dbSet) : base(dbSet) { }

        protected override void Seed() {

            for (int i = 0; i < 5; i++) {
                dbSet.Add(UserFactory.Create());
            }
        }
    }
}