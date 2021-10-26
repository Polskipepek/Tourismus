using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourismus.Model.Models;

namespace WebApi.Model.Configuration.Entities {
    class CityConfiguration : IEntityTypeConfiguration<City> {
        private const string _CountryId = "FK_Cities_Countries";

        public void Configure(EntityTypeBuilder<City> builder) {
            builder.HasComment("Cities");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(d => d.IdNavigation)
                .WithOne(p => p.City)
                .HasForeignKey<City>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName(_CountryId);
        }
    }
}
