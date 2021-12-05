using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourismus.Model.Models;

namespace Tourismus.Model.Configuration.Models {
    class UserCredentialConfiguration : IEntityTypeConfiguration<UserCredential> {
        public void Configure(EntityTypeBuilder<UserCredential> entity) {
            entity.HasKey(x => x.Id);

            entity.Property(e => e.Hash)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.Property(e => e.Salt)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserCredentials)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserCredentials_Users");
        }
    }
}