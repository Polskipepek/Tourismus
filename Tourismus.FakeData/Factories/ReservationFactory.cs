using System;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.Factories {
    public class ReservationFactory {
        public static Reservation Create(Meal meal,City city) {
            return new() {
                ReservationDate = DateTime.Now - TimeSpan.FromHours(Faker.RandomNumber.Next(1, 1000)),
                IsPaid = Faker.Boolean.Random(),
                Offer = OfferFactory.Create(meal,city),
                User = UserFactory.Create(),
            };
        }
    }
}
