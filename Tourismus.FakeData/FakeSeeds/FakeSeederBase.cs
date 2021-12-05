using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Tourismus.FakeData.FakeSeeds {
    abstract class FakeSeederBase<TModel> where TModel : class {
        public FakeSeederBase(DbSet<TModel> dbSet) {
            this.dbSet = dbSet;
        }

        protected readonly DbSet<TModel> dbSet;

        public void SeedIfNotSeeded() {
            if (!dbSet.Any()) {
                Seed();
            }
        }

        protected abstract void Seed();
    }
}
