using System.Collections.Generic;
using Tourismus.Model.Configuration._Infrastructure;

namespace Api.Model.Database {
    public partial class Meal : ModelBase {
        public Meal() {
            Offers = new HashSet<Offer>();
        }

        public string Name { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}
