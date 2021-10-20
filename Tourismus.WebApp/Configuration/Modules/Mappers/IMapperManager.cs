using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tourismus.WebApp.Configuration.Modules.Mappers {
    public interface IMapperManager {
        public Task<IEnumerable<TDto>> ExecuteMap<TEntity, TDto>(IQueryable<TEntity> collection, CancellationToken token)
            where TDto : class
            where TEntity : class;

        public TDto ExecuteMap<TEntity, TDto>(TEntity tEntity)
            where TDto : class
            where TEntity : class;
    }
}