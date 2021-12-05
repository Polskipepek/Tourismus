using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourismus.Model.Models;

namespace Tourismus.Model.Configuration.Models {
    class OfferConfiguration : IEntityTypeConfiguration<Offer> {
        public void Configure(EntityTypeBuilder<Offer> entity) {
            entity.HasKey(x => x.Id);

            entity.Property(e => e.DateFrom).HasColumnType("datetime");

            entity.Property(e => e.DateTo).HasColumnType("datetime");

            entity.Property(e => e.Description).IsRequired();

            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.City)
                .WithMany(p => p.Offers)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Offers_Cities");

            entity.HasOne(d => d.Hotel)
                .WithMany(p => p.Offers)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Offers_Hotels");

            entity.HasOne(d => d.Meals)
                .WithMany(p => p.Offers)
                .HasForeignKey(d => d.MealsId)
                .HasConstraintName("FK_Offers_Meals");
        }
    }
}
