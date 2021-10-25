using Api.Model.Database;

namespace Tourismus.FakeData.Factories {
    public class OfferFactory {
        public static Offer Create() {
            return new() {
                CityId = Faker.RandomNumber.Next(),

            };
        }


    }
}
