using Microsoft.EntityFrameworkCore;
using Tourismus.FakeData.Factories;
using Tourismus.Model.Models;

namespace Tourismus.FakeData.FakeSeeds.Seeders {
    class ReservationFakeSeeder : FakeSeederBase<Reservation> {
        public ReservationFakeSeeder(DbSet<Reservation> dbSet) : base(dbSet) { }

        protected override void Seed() {
            for (int i = 0; i < 5; i++) {
                dbSet.Add(ReservationFactory.Create());
            }
        }
    }
}
