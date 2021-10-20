using Api.Model.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.Model.Configuration.Entities {
    class UserCredentialsConfiguration : IEntityTypeConfiguration<UserCredential> {
        public void Configure(EntityTypeBuilder<UserCredential> builder) {
            builder.HasComment("UsersCredentials");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Identificator").ValueGeneratedOnAdd();
            builder.Property(b => b.Hash).HasComment("Hash");
            builder.Property(b => b.Salt).HasComment("Salt");
            builder.Property(b => b.Token).HasComment("Token");
        }
    }
}
