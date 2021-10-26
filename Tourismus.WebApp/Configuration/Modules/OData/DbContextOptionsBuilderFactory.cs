using Microsoft.EntityFrameworkCore;
using Tourismus.Model.Models;

namespace Tourismus.WebApp.Configuration.Modules.OData {
    public static class DbContextOptionsBuilderFactory {

        public static DbContextOptionsBuilder<TourismusDbContext> CreateTourismusDbConfiguration(string connectionString) {
            var conf = new DbContextOptionsBuilder<TourismusDbContext>()
                    //.UseLazyLoadingProxies()
                    .UseSqlServer(connectionString, options => options.UseNetTopologySuite());

            return conf;
        }
    }
}
