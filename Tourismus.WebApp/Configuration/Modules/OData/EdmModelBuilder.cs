using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace Tourismus.WebApp.Configuration.Modules.OData {
    public class EdmModelBuilder {
        public static IEdmModel GetModel() {
            var builder = new ODataConventionModelBuilder();

            new WebApiODataModule(builder).Configure();

            return builder.GetEdmModel();
        }
    }
}
