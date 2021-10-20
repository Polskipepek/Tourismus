using Microsoft.Extensions.Configuration;

namespace Tourismus.WebApp.Configuration.Modules.AppConfiguration {
    public class AppConfig {

        public AppConfig(IConfiguration configuration) {
            this.configuration = configuration;
        }
        public string WebApiConnectionString => GetConnectionString(nameof(WebApiConnectionString));

        public string WebApiUrl => GetUrl(nameof(WebApiUrl));

        private readonly IConfiguration configuration;

        private string GetUrl(string name) {
            return configuration.GetSection("Urls")[name];
        }

        private string GetConnectionString(string name) {
            return configuration.GetSection("ConnectionStrings")[name];
        }
    }
}
