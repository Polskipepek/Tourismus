using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Tourismus.Model.Models;
using Tourismus.WebApp.Configuration.Modules.OData;
using Tourismus.WebApp.ReadModels.Dtos.List;
using Tourismus.WebApp.ReadModels.Dtos.Single;

namespace Pwa.Controllers._OData.Product {
    [ResponseCache(CacheProfileName = "NoCaching")]
    public class OffersController : ODataController {
        private readonly TourismusDbContext _webApiDbContext;
        private readonly ODataListHandler _oDataListHandler;
        private readonly ODataSingleHandler _oDataSingleHandler;

        public OffersController(TourismusDbContext webApiDbContext, ODataListHandler oDataListHandler, ODataSingleHandler oDataSingleHandler) {
            _webApiDbContext = webApiDbContext;
            _oDataSingleHandler = oDataSingleHandler;
            _oDataListHandler = oDataListHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(ODataQueryOptions<Offer> opts, CancellationToken token) => await _oDataListHandler.ExecuteGetList<Offer, Offer_ListDto>(opts, _webApiDbContext.Offers, token);

        [HttpGet]
        public IActionResult Get(ODataQueryOptions<Offer> opts) => _oDataSingleHandler.ExecuteGet<Offer, Offer_DetailsDto>(opts, _webApiDbContext.Offers);

    }
}
