using Api.Model.Database;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Tourismus.WebApp.Configuration.Modules.OData {
    public class ODataModule : Module {
        private readonly DbContextOptionsBuilder<TourismusDBContext> _dbContextOptions;

        public ODataModule(string connectionString) {
            _dbContextOptions = DbContextOptionsBuilderFactory.CreateTourismusDbConfiguration(connectionString);
        }

        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<ODataListHandler>();
            builder.RegisterType<ODataSingleHandler>();
            builder
                .Register(c => new TourismusDBContext(_dbContextOptions.Options))
                .InstancePerLifetimeScope();
        }
    }
}
