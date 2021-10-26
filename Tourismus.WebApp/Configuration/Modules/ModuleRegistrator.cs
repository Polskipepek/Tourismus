using Autofac;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Tourismus.WebApp.Configuration.Modules.AppConfiguration;
using Tourismus.WebApp.Configuration.Modules.Authentication;
using Tourismus.WebApp.Configuration.Modules.Mappers;
using Tourismus.WebApp.Configuration.Modules.OData;

namespace Tourismus.WebApp.Configuration.Modules {
    public static class ModuleRegistrator {

        public static void RegisterAllModules(ContainerBuilder builder, params System.Reflection.Assembly[] additionalAssemblies) {
            RegisterAllAssemblies(builder, additionalAssemblies);

            var configuration = GetConfiguration();

            builder.RegisterModule(new AppConfigModule(configuration));
            builder.RegisterModule(new ODataModule(configuration.GetConnectionString(nameof(AppConfig.TourismusConnectionString))));

            builder.RegisterModule<AuthenticationModule>();
            builder.RegisterModule<MapperModule>();
        }

        private static void RegisterAllAssemblies(ContainerBuilder builder, IEnumerable<System.Reflection.Assembly> additionalAssemblies) {
            var assemblies = new System.Reflection.Assembly[] {
                //Additional assemblies
            }.Concat(additionalAssemblies).ToArray();

            builder.RegisterAssemblyModules(assemblies);
        }

        private static IConfiguration GetConfiguration() {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return configuration;
        }
    }
}
