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
                .WithMany(c=>c.Offers)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Hotel)
                .WithMany(h=>h.Offers)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Meal)
                .WithMany(m=>m.Offers)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
