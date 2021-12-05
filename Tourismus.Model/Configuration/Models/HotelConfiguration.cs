using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tourismus.Model.Models;

namespace Tourismus.Model.Configuration.Models {
    class HotelConfiguration : IEntityTypeConfiguration<Hotel> {
        public void Configure(EntityTypeBuilder<Hotel> entity) {
            entity.HasKey(x => x.Id);


            entity.Property(e => e.Name).HasMaxLength(100);

        }
    }
}
