using Api.Model.Database;
using Microsoft.EntityFrameworkCore;

namespace Tourismus.WebApp.Configuration.Modules.OData {
    public static class DbContextOptionsBuilderFactory {

        public static DbContextOptionsBuilder<TourismusDBContext> CreateTourismusDbConfiguration(string connectionString) {
            var conf = new DbContextOptionsBuilder<TourismusDBContext>()
                    //.UseLazyLoadingProxies()
                    .UseSqlServer(connectionString, options => options.UseNetTopologySuite());

            return conf;
        }
    }
}
