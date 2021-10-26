using Microsoft.EntityFrameworkCore;
using Tourismus.FakeData.Factories;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.FakeSeeds.Seeders {
    class UserCredentialFakeSeeder : FakeSeederBase<UserCredential> {

        public UserCredentialFakeSeeder(DbSet<UserCredential> dbSet) : base(dbSet) { }

        protected override void Seed() {

            for (int i = 0; i < 5; i++) {
                dbSet.Add(UserCredentialFactory.Create());
            }
        }
    }
}