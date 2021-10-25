using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApi.Model.Configuration.Entities;

namespace Api.Model.Database {
    public partial class TourismusDbContext : DbContext {
        public TourismusDbContext() { }

        public TourismusDbContext(DbContextOptions<TourismusDbContext> options) : base(options) { }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        private const string TourismusConnectionString = "TourismusConnectionString";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                var connectionString = ConfigurationManager.ConnectionStrings[TourismusConnectionString].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString, x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new MealConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserCredentialsConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
