using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tourismus.WebApp.Configuration.Modules.Mappers;

namespace Tourismus.WebApp.Configuration.Modules.OData {

    public class ODataListHandler {
        private const int MaxPageSize = 100;
        private const int ODataMaxAnyAllExpressionDepth = 5;
        private const int ODataQueryMaxNodeCount = 1000;

        private readonly IMapperManager _mapperManager;

        public ODataListHandler(IMapperManager mapperManager) {
            _mapperManager = mapperManager;
        }

        public async Task<IActionResult> ExecuteGetList<TEntity, TResult>(ODataQueryOptions<TEntity> opts, IQueryable<TEntity> query, CancellationToken token, int maxPageSize = MaxPageSize)
            where TEntity : class
            where TResult : class {

            var result = await FilterAndMap<TEntity, TResult>(opts, query, maxPageSize, token);

            return new OkObjectResult(result);
        }

        private async Task<IEnumerable<TResult>> FilterAndMap<TEntity, TResult>(ODataQueryOptions<TEntity> opts, IQueryable<TEntity> query, int maxPageSize, CancellationToken token)
            where TEntity : class
            where TResult : class {
            ValidateODataQuery(opts, maxPageSize);
            var filterData = opts.ApplyTo(query) as IQueryable<TEntity>;

            if (opts.Top == null) {
                filterData = filterData.Take(maxPageSize);
            }
            return await _mapperManager.ExecuteMap<TEntity, TResult>(filterData, token);
        }

        private void ValidateODataQuery<TEntity>(ODataQueryOptions<TEntity> opts, int maxPageSize) where TEntity : class {
            opts.Validate(new ODataValidationSettings() {
                MaxTop = maxPageSize,
                MaxNodeCount = ODataQueryMaxNodeCount,
                MaxAnyAllExpressionDepth = ODataMaxAnyAllExpressionDepth,
            });
        }
    }
}
