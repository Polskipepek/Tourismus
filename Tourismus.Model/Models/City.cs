using System.Collections.Generic;

namespace Tourismus.Model.Models {
    public class City {
        public City() {
            Hotels = new HashSet<Hotel>();
            Offers = new HashSet<Offer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public bool IsAirport { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}