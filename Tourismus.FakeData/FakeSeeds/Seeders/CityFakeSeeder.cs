using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tourismus.FakeData.Factories;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.FakeSeeds.Seeders {
    class CityFakeSeeder : FakeSeederBase<City, IEnumerable<City>> {
        public CityFakeSeeder(DbSet<City> dbSet) : base(dbSet) { }

        IEnumerable<Country> countries;

        public CityFakeSeeder Initialize(IEnumerable<Country> country) {
            this.countries = country;
            return this;
        }

        public override IEnumerable<City> SeedWithResult()  {
            var countryIter = countries.GetEnumerator();
            for (int i = 0; i < 10; i++) {
                if (!countryIter.MoveNext()) {
                    countryIter.Reset();
                    countryIter.MoveNext();
                }

                var city = CityFactory.Create();
                city.Country = countryIter.Current;
                dbSet.Add(city);
                yield return city;
            }
        }

        public override void Seed() {
            for (int i = 0; i < 10; i++) {
                CityFactory.Create();
            }
        }
    }
}
