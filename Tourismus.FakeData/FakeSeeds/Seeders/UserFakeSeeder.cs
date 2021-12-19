using Microsoft.EntityFrameworkCore;
using Tourismus.FakeData.Factories;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.FakeSeeds.Seeders {
    class UserFakeSeeder : FakeSeederBase<User, Unit> {

        public UserFakeSeeder(DbSet<User> dbSet) : base(dbSet) { }

        public override void Seed() {

            for (int i = 0; i < 10; i++) {
                dbSet.Add(UserFactory.Create());
            }

        }
    }
}