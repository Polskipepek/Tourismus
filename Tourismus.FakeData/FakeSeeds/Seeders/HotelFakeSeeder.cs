using Microsoft.EntityFrameworkCore;
using Tourismus.FakeData.Factories;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.FakeSeeds.Seeders {
    class HotelFakeSeeder : FakeSeederBase<Hotel, Unit> {
        public HotelFakeSeeder(DbSet<Hotel> dbSet) : base(dbSet) { }

        public override void Seed() {
            for (int i = 0; i < 50; i++) {
                dbSet.Add(HotelFactory.Create());
            }
        }
    }
}
