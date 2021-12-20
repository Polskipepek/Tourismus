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
    public class ReservationsController : ODataController {
        private readonly TourismusDbContext _webApiDbContext;
        private readonly ODataListHandler _oDataListHandler;
        private readonly ODataSingleHandler _oDataSingleHandler;

        public ReservationsController(TourismusDbContext webApiDbContext, ODataListHandler oDataListHandler, ODataSingleHandler oDataSingleHandler) {
            _webApiDbContext = webApiDbContext;
            _oDataSingleHandler = oDataSingleHandler;
            _oDataListHandler = oDataListHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(ODataQueryOptions<Reservation> opts, CancellationToken token) => await _oDataListHandler.ExecuteGetList<Reservation, Reservation_ListDto>(opts, _webApiDbContext.Reservations, token);

      //  [HttpGet]
       // public IActionResult Get(ODataQueryOptions<Reservation> opts) => _oDataSingleHandler.ExecuteGet<Reservation, Reservation_ListDto>(opts, _webApiDbContext.Reservations);

    }
}
