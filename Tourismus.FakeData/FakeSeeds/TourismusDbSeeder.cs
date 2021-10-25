using Api.Model.Database;
using Tourismus.FakeData.FakeSeeds.Seeders;

namespace Tourismus.FakeData.FakeSeeds {
    public class TourismusDbSeeder {

        public void SeedFakeData(TourismusDbContext context) {
            new UserFakeSeeder(context.Users).SeedIfNotSeeded();
        }
    }
}
