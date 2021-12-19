using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tourismus.Model.Models {
    public class Meal : EntityBase {
        public Meal() {
            Offers = new HashSet<Offer>();
        }

        public string Name { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}