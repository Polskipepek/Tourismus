using System;
using System.Collections.Generic;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.Factories {
    public class OfferFactory {
        public static Offer Create(Meal meal, City city) {
            DateTime dateTime = new DateTime(2020,1,1);
            return new() {
                City = city,
                DateFrom = dateTime.AddDays(Faker.RandomNumber.Next(10,300)),
                DateTo = dateTime.AddDays(Faker.RandomNumber.Next(100,400)),
                Hotel = HotelFactory.Create(),
                Description = Faker.Lorem.Sentence(1),
                Name = Faker.Lorem.Sentence(1), 
                NumberOfPeople = Faker.RandomNumber.Next(1,10),
                Price = Faker.RandomNumber.Next(50,10000),
                Meal =  meal,
            };
        }


    }
}
