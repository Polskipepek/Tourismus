using Autofac;
using Tourismus.WebApp.ReadModels._Infrastructure.Mappers;

namespace Tourismus.WebApp.Configuration.Modules.Mappers.Factories {
    class MapperHandlerFactory {
        private readonly ILifetimeScope _lifetimeScope;

        public MapperHandlerFactory(ILifetimeScope lifetimeScope) {
            _lifetimeScope = lifetimeScope;
        }

        public IHandleMapper<TEntity, TResult> CreateLists<TEntity, TResult>()
            where TEntity : class
            where TResult : class {
            var handlerType = typeof(IHandleMapper<,>).MakeGenericType(typeof(TEntity), typeof(TResult));
            return (IHandleMapper<TEntity, TResult>)_lifetimeScope.Resolve(handlerType);
        }

        public ISingleHandleMapper<TEntity, TResult> CreateSingles<TEntity, TResult>()
            where TEntity : class
            where TResult : class {
            var handlerType = typeof(ISingleHandleMapper<,>).MakeGenericType(typeof(TEntity), typeof(TResult));
            return (ISingleHandleMapper<TEntity, TResult>)_lifetimeScope.Resolve(handlerType);
        }
    }
}
