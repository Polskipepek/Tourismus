using System.Collections.Generic;

namespace Api.Model.Database {
    public partial class Meal {
        public Meal() {
            Offers = new HashSet<Offer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}
