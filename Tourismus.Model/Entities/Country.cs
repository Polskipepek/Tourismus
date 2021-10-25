using Tourismus.Model.Configuration._Infrastructure;

namespace Api.Model.Database {
    public partial class Country : ModelBase {
        public string Name { get; set; }

        public virtual City City { get; set; }
    }
}
