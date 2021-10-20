using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tourismus.WebApp.ReadModels._Infrastructure.Mappers {
    public interface IHandleMapper {
    }

    public interface IHandleMapper<TEntity, TResult> : IHandleMapper
        where TEntity : class
        where TResult : class {
        Task<List<TResult>> Handle(IQueryable<TEntity> entities, CancellationToken token);
    }
    public interface ISingleHandleMapper : IHandleMapper { }

    public interface ISingleHandleMapper<TEntity, TResult> : IHandleMapper
    where TEntity : class
    where TResult : class {
        TResult Handle(TEntity tEntity);
    }
}
