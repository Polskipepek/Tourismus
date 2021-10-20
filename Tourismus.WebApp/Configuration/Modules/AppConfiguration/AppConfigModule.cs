using Autofac;
using Microsoft.Extensions.Configuration;

namespace Tourismus.WebApp.Configuration.Modules.AppConfiguration {
    public class AppConfigModule : Module {

        private readonly IConfiguration configuration;

        public AppConfigModule(IConfiguration configuration) {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder) {
            builder.Register(x => new AppConfig(configuration)).AsSelf().SingleInstance();
        }
    }
}
