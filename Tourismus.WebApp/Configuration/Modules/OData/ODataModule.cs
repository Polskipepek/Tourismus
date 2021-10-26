using Autofac;
using Microsoft.EntityFrameworkCore;
using Tourismus.Model.Models;

namespace Tourismus.WebApp.Configuration.Modules.OData {
    public class ODataModule : Module {
        private readonly DbContextOptionsBuilder<TourismusDbContext> _dbContextOptions;

        public ODataModule(string connectionString) {
            _dbContextOptions = DbContextOptionsBuilderFactory.CreateTourismusDbConfiguration(connectionString);
        }

        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<ODataListHandler>();
            builder.RegisterType<ODataSingleHandler>();
            builder
                .Register(c => new TourismusDbContext(_dbContextOptions.Options))
                .InstancePerLifetimeScope();
        }
    }
}
