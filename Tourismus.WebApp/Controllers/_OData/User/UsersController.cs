using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Tourismus.Model.Models;
using Tourismus.WebApp.Configuration.Modules.OData;
using Tourismus.WebApp.ReadModels.Dtos.Single;

namespace Pwa.Controllers._OData.Customer {
    [ResponseCache(CacheProfileName = "NoCaching")]
    public class UsersController : ODataController {
        private readonly TourismusDbContext _webApiDbContext;
        private readonly ODataListHandler _oDataListHandler;
        private readonly ODataSingleHandler _oDataSingleHandler;

        public UsersController(TourismusDbContext webApiDbContext, ODataListHandler oDataListHandler, ODataSingleHandler oDataSingleHandler) {
            _webApiDbContext = webApiDbContext;
            _oDataSingleHandler = oDataSingleHandler;
            _oDataListHandler = oDataListHandler;
        }

        [HttpGet]
        public IActionResult Get(ODataQueryOptions<User> opts) => _oDataSingleHandler.ExecuteGet<User, User_Dto>(opts, _webApiDbContext.Users);
    }
}
