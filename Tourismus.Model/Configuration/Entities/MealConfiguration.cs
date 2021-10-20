using Api.Model.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.Model.Configuration.Entities {
    class MealConfiguration : IEntityTypeConfiguration<Meal> {

        public void Configure(EntityTypeBuilder<Meal> builder) {
            builder.HasComment("Meals");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
        }
    }
}
