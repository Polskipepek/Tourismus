using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourismus.Model.Models;

namespace WebApi.Model.Configuration.Entities {
    class UserCredentialsConfiguration : IEntityTypeConfiguration<UserCredential> {
        public void Configure(EntityTypeBuilder<UserCredential> builder) {
            builder.HasComment("UsersCredentials");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Identificator").ValueGeneratedOnAdd();
            builder.Property(b => b.Hash).HasComment("Hash");
            builder.Property(b => b.Salt).HasComment("Salt");
        }
    }
}
