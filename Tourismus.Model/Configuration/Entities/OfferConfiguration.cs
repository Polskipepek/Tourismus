using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourismus.Model.Models;

namespace WebApi.Model.Configuration.Entities {
    class OfferConfiguration : IEntityTypeConfiguration<Offer> {
        private const string _MealId = "FK_Offers_Meals";
        private const string _CityId = "FK_Offers_Cities";

        public void Configure(EntityTypeBuilder<Offer> builder) {
            builder.HasComment("Offers");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.DateFrom).HasColumnType("datetime");

            builder.Property(e => e.DateTo).HasColumnType("datetime");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Price).HasColumnType("money");

            builder.HasOne(d => d.City)
                .WithMany(p => p.Offers)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName(_CityId);

            builder.HasOne(d => d.Meals)
                .WithMany(p => p.Offers)
                .HasForeignKey(d => d.MealsId)
                .HasConstraintName(_MealId);
        }
    }
}
