using Api.Model.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.Model.Configuration.Entities {
    class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> builder) {
            builder.HasComment("Users");

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id).HasComment("Identificator").ValueGeneratedNever();

            builder.Property(e => e.AccountCreationDate).HasColumnType("datetime");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.TelephoneNumber)
                .IsRequired()
                .HasMaxLength(100);


        }
    }
}
