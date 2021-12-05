using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourismus.Model.Models;

namespace Tourismus.Model.Configuration.Models {
    class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> entity) {
            entity.HasKey(x => x.Id);

            entity.Property(e => e.AccountCreationDate).HasColumnType("datetime");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.TelephoneNumber)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Token).HasMaxLength(1000);
        }
    }
}