using Autofac;
using Tourismus.WebApp._Infrastructure.Authentication;

namespace Tourismus.WebApp.Configuration.Modules.Authentication {
    public class AuthenticationModule : Module {

        public AuthenticationModule() {

        }

        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<UserService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
