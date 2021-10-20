using Microsoft.AspNet.OData.Builder;

namespace Tourismus.WebApp.Configuration.Modules.OData {
    public class WebApiODataModule {
        readonly ODataConventionModelBuilder builder;
        public WebApiODataModule(ODataConventionModelBuilder builder) {
            this.builder = builder;
        }

        internal void Configure() {
            //  builder.EntitySet<Products>("Products").AddGetList<Products, Product_ListDto>();
            //   builder.EntitySet<ShopCategories>("ShopCategories").AddGetList<ShopCategories, ShopCategory_ListDto>();
            //   builder.EntitySet<Customers>("Customers");
        }
    }
}