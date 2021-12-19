using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tourismus.FakeData.Factories;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.FakeSeeds.Seeders {
    class ReservationFakeSeeder : FakeSeederBase<Reservation, Unit> {
        public ReservationFakeSeeder(DbSet<Reservation> dbSet) : base(dbSet) { }

        private IEnumerable<Meal> meals;
        private IEnumerable<City> cities;

        public ReservationFakeSeeder Initialize(IEnumerable<Meal> meals, IEnumerable<City> cities) {
            this.meals = meals;
            this.cities = cities;
            return this;
        }

        public override void Seed() {
            var mealIter = meals.GetEnumerator();
            var cityIter = cities.GetEnumerator();

            for (int i = 0; i < 15; i++) {
                if (!mealIter.MoveNext()) {
                    mealIter.Reset();
                    mealIter.MoveNext();
                }
                if (!cityIter.MoveNext()) {
                    cityIter.Reset();
                    cityIter.MoveNext();
                    cityIter.MoveNext();
                }

                dbSet.Add(ReservationFactory.Create(mealIter.Current, cityIter.Current));
            }
        }
    }
}
