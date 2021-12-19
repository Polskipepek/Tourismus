using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Tourismus.FakeData.FakeSeeds {
    abstract class FakeSeederBase<TModel, TResult> where TModel : class {
        public FakeSeederBase(DbSet<TModel> dbSet) {
            this.dbSet = dbSet;
        }

        protected readonly DbSet<TModel> dbSet;

        public abstract void Seed();

        public virtual TResult SeedWithResult() {
            throw new NotImplementedException();
        }
    }
}
