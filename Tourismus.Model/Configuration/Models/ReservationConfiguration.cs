using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourismus.Model.Models;

namespace Tourismus.Model.Configuration.Models {
    class ReservationConfiguration : IEntityTypeConfiguration<Reservation> {
        public void Configure(EntityTypeBuilder<Reservation> entity) {
            entity.HasKey(x => x.Id);

            entity.Property(e => e.ReservationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Offer)
                .WithMany(p => p.Reservations)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservations_Offers");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservations_Users");
        }
    }
}
