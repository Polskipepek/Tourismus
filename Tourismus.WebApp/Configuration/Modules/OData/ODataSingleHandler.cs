using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Tourismus.WebApp.Configuration.Modules.Mappers;

namespace Tourismus.WebApp.Configuration.Modules.OData {

    public class ODataSingleHandler {
        private const int ODataMaxAnyAllExpressionDepth = 5;
        private const int ODataQueryMaxNodeCount = 1000;

        private readonly IMapperManager _mapperManager;

        public ODataSingleHandler(IMapperManager mapperManager) {
            _mapperManager = mapperManager;
        }

        public IActionResult ExecuteGet<TEntity, TResult>(ODataQueryOptions<TEntity> opts, IQueryable<TEntity> query)
            where TEntity : class
            where TResult : class {

            ValidateODataQuery(opts);

            TResult entity;

            try {
                var tEntity = (opts.ApplyTo(query) as IEnumerable<TEntity>).Single();
                entity = _mapperManager.ExecuteMap<TEntity, TResult>(tEntity);
            } catch (Exception) {
                return new BadRequestResult();
            }

            return new OkObjectResult(entity);
        }

        private void ValidateODataQuery<TEntity>(ODataQueryOptions<TEntity> opts) where TEntity : class {
            opts.Validate(new ODataValidationSettings() {
                MaxNodeCount = ODataQueryMaxNodeCount,
                MaxAnyAllExpressionDepth = ODataMaxAnyAllExpressionDepth,
            });
        }
    }
}
