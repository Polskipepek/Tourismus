using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourismus.Model.Models;

namespace Tourismus.Model.Configuration.Models {
    class CountryConfiguration : IEntityTypeConfiguration<Country> {
        public void Configure(EntityTypeBuilder<Country> entity) {
            entity.HasKey(x => x.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
