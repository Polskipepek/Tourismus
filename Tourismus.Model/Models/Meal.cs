using System.Collections.Generic;


namespace Tourismus.Model.Models {
    public class Meal {
        public Meal() {
            Offers = new HashSet<Offer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}