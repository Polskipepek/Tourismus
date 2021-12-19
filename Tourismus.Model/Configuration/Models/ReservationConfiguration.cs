using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourismus.Model.Models;

namespace Tourismus.Model.Configuration.Models {
    class ReservationConfiguration : IEntityTypeConfiguration<Reservation> {
        public void Configure(EntityTypeBuilder<Reservation> entity) {
            entity.HasKey(x => x.Id);

            entity.Property(e => e.ReservationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Offer)
                .WithMany(o => o.Reservations)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User)
                .WithMany(u => u.Reservations)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
