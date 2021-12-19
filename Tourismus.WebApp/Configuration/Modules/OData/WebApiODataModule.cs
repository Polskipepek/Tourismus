using Microsoft.AspNet.OData.Builder;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels.Dtos.List;

namespace Tourismus.WebApp.Configuration.Modules.OData {
    public class WebApiODataModule {
        readonly ODataConventionModelBuilder builder;
        public WebApiODataModule(ODataConventionModelBuilder builder) {
            this.builder = builder;
        }

        internal void Configure() {
            builder.EntitySet<Offer>("Offers").AddGetList<Offer, Offer_ListDto>();
            builder.EntitySet<Meal>("Meals").AddGetList<Meal, Meal_ListDto>();
            builder.EntitySet<Hotel>("Hotels").AddGetList<Hotel, Hotel_ListDto>();
            //builder.EntitySet<City>("Cities").AddGetList<City, City_Dto>();
            //builder.EntitySet<Country>("Countries").AddGetList<Country, Country_Dto>();
        }
    }
}