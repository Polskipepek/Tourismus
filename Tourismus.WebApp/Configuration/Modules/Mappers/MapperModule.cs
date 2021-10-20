using Autofac;
using System.Linq;
using Tourismus.WebApp.Configuration.Modules.Mappers.Factories;
using Tourismus.WebApp.ReadModels._Infrastructure;
using Tourismus.WebApp.ReadModels._Infrastructure.Mappers;

namespace Tourismus.WebApp.Configuration.Modules.Mappers {
    class MapperModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<MapperManager>().As<IMapperManager>();
            builder.RegisterType<MapperBus>();

            builder.RegisterType<MapperHandlerFactory>();

            builder.RegisterAssemblyTypes(typeof(ITourismusReadModelsAssemblyMarker).Assembly)
               .Where(x => x.IsAssignableTo<IHandleMapper>() || x.IsAssignableTo<ISingleHandleMapper>())
               .AsImplementedInterfaces();
        }
    }
}
