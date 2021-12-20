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
    public class HotelsController : ODataController {
        private readonly TourismusDbContext _webApiDbContext;
        private readonly ODataListHandler _oDataListHandler;
        private readonly ODataSingleHandler _oDataSingleHandler;

        public HotelsController(TourismusDbContext webApiDbContext, ODataListHandler oDataListHandler, ODataSingleHandler oDataSingleHandler) {
            _webApiDbContext = webApiDbContext;
            _oDataSingleHandler = oDataSingleHandler;
            _oDataListHandler = oDataListHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(ODataQueryOptions<Hotel> opts, CancellationToken token) => await _oDataListHandler.ExecuteGetList<Hotel, Hotel_ListDto>(opts, _webApiDbContext.Hotels, token);

        //[HttpGet]
        //public IActionResult Get(ODataQueryOptions<Hotel> opts) => _oDataSingleHandler.ExecuteGet<Hotel, Hotel_ListDto>(opts, _webApiDbContext.Hotels);

    }
}
