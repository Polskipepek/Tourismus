using System;
using System.Collections.Generic;
using System.Linq;
using Tourismus.FakeData.FakeSeeds.Seeders;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.FakeSeeds {
    public class TourismusDbSeeder {

        public void SeedFakeData(TourismusDbContext context) {
            var meals = new MealFakeSeeder(context.Meals).SeedWithResult().ToList();
            var countries = new CountryFakeSeeder(context.Countries).SeedWithResult().ToList();
            var cities = new CityFakeSeeder(context.Cities).Initialize(countries).SeedWithResult().ToList();

            new UserFakeSeeder(context.Users).Seed();
            new ReservationFakeSeeder(context.Reservations).Initialize(meals, cities).Seed();

            //new OfferFakeSeeder(context.Offers).Seed();
            //new HotelFakeSeeder(context.Hotels).Seed();

            context.SaveChanges();
        }
    }
}