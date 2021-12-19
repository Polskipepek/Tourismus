using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tourismus.FakeData.Factories;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.FakeSeeds.Seeders {
    class CountryFakeSeeder : FakeSeederBase<Country, IEnumerable<Country>> {
        public CountryFakeSeeder(DbSet<Country> dbSet) : base(dbSet) { }

        public override void Seed() {
            for (int i = 0; i < 5; i++) {
              dbSet.Add(CountryFactory.Create());
            }
        }
        public override IEnumerable<Country> SeedWithResult() {
            yield return CountryFactory.Create();
            for (int i = 0; i < 5; i++) {
                var country = CountryFactory.Create();
                dbSet.Add(country);
                yield return country;
            }
        }
    }
}
