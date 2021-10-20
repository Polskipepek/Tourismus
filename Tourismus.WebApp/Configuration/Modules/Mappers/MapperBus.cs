using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tourismus.WebApp.Configuration.Modules.Mappers.Factories;

namespace Tourismus.WebApp.Configuration.Modules.Mappers {
    class MapperBus {
        private readonly MapperHandlerFactory _handlersFactory;

        public MapperBus(MapperHandlerFactory handlersFactory) {
            _handlersFactory = handlersFactory;
        }

        public async Task<IEnumerable<TResult>> Send<TEntity, TResult>(IQueryable<TEntity> entities, CancellationToken token)
            where TEntity : class
            where TResult : class {
            var mapperHandler = _handlersFactory.CreateLists<TEntity, TResult>();

            if (mapperHandler == null) {
                throw new Exception($"Brak handlera dla entity [{typeof(TEntity).FullName}], result [{typeof(TResult).FullName}]");
            }

            return await mapperHandler.Handle(entities, token);
        }

        public TResult Send<TEntity, TResult>(TEntity tEntitY)
            where TEntity : class
            where TResult : class {
            var mapperHandler = _handlersFactory.CreateSingles<TEntity, TResult>();

            if (mapperHandler == null) {
                throw new Exception($"Brak handlera dla entity [{typeof(TEntity).FullName}], result [{typeof(TResult).FullName}]");
            }

            return mapperHandler.Handle(tEntitY);
        }
    }
}
