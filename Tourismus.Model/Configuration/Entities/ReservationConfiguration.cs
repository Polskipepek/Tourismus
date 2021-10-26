using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourismus.Model.Models;

namespace WebApi.Model.Configuration.Entities {
    class ReservationConfiguration : IEntityTypeConfiguration<Reservation> {
        public static string OfferId = "FK_Reservations_Offers";
        public static string UserId = "FK_Reservations_Users";

        public void Configure(EntityTypeBuilder<Reservation> builder) {
            builder.HasComment("Reservations");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.ReservationDate).HasColumnType("datetime");

            builder.HasOne(d => d.Offer)
                .WithMany(p => p.Reservations)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName(OfferId);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName(UserId);
        }
    }
}