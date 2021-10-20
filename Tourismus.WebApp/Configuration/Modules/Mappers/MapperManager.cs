using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tourismus.WebApp.Configuration.Modules.Mappers {
    class MapperManager : IMapperManager {
        private readonly MapperBus _mapperBus;

        public MapperManager(MapperBus mapperBus) {
            _mapperBus = mapperBus;
        }
        public async Task<IEnumerable<TDto>> ExecuteMap<TEntity, TDto>(IQueryable<TEntity> collection, CancellationToken token)
            where TDto : class
            where TEntity : class {

            return await _mapperBus.Send<TEntity, TDto>(collection, token);
        }

        public TDto ExecuteMap<TEntity, TDto>(TEntity tEntity)
            where TEntity : class
            where TDto : class {

            return _mapperBus.Send<TEntity, TDto>(tEntity);
        }
    }
}
