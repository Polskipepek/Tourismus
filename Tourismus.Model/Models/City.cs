using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tourismus.Model.Models {
    public class City : EntityBase {
        public City() {
            Hotels = new HashSet<Hotel>();
            Offers = new HashSet<Offer>();
        }

        public string Name { get; set; }
        public bool IsAirport { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}