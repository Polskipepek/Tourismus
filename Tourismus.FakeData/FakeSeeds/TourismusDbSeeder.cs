using Tourismus.FakeData.FakeSeeds.Seeders;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.FakeSeeds {
    public class TourismusDbSeeder {

        public void SeedFakeData(TourismusDbContext context) {
            new UserFakeSeeder(context.Users).SeedIfNotSeeded();
        }
    }
}
