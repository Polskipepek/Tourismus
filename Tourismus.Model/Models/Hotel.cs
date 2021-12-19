using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tourismus.Model.Models {
    public class Hotel : EntityBase {
        public Hotel() {
            Offers = new HashSet<Offer>();
        }

        public string Name { get; set; }
        public int Star { get; set; }
        public string Description { get; set; }
        public string PhotosPaths { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}