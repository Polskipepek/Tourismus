using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tourismus.FakeData.Factories;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.FakeSeeds.Seeders {
    class OfferFakeSeeder : FakeSeederBase<Offer, Unit> {

        public OfferFakeSeeder(DbSet<Offer> dbSet) : base(dbSet) { }

        private IEnumerable<Meal> meals;
        private IEnumerable<City> cities;

        public OfferFakeSeeder Initialize(IEnumerable<Meal> meals, IEnumerable<City> cities) {
            this.meals = meals;
            return this;
        }
        public override void Seed() {
            var mealIter = meals.GetEnumerator();
            var cityIter = cities.GetEnumerator();
            
            for (int i = 0; i < 15; i++) {
                if (!mealIter.MoveNext()) {
                    mealIter.Reset();
                }

                dbSet.Add(OfferFactory.Create(mealIter.Current, cityIter.Current));
            }
        }
    }
}