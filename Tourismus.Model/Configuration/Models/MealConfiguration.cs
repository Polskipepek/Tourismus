using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourismus.Model.Models;

namespace Tourismus.Model.Configuration.Models {
    class MealConfiguration : IEntityTypeConfiguration<Meal> {
        public void Configure(EntityTypeBuilder<Meal> entity) {
            entity.HasKey(x => x.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
