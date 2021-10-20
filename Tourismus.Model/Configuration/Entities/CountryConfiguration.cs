using Api.Model.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.Model.Configuration.Entities {
    class CountryConfiguration : IEntityTypeConfiguration<Country> {

        public void Configure(EntityTypeBuilder<Country> builder) {
            builder.HasComment("Countries");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
        }
    }
}
