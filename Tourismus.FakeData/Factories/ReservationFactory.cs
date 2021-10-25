using Api.Model.Database;
using System;

namespace Tourismus.FakeData.Factories {
    public class ReservationFactory {
        public static Reservation Create() {
            return new() {
                ReservationDate = DateTime.Now - TimeSpan.FromHours(Faker.RandomNumber.Next(1, 1000)),
                IsPaid = Faker.Boolean.Random(),
                OfferId = Faker.RandomNumber.Next(),
                UserId = Faker.RandomNumber.Next(),
            };
        }
    }
}
