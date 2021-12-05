using System.Collections.Generic;

namespace Tourismus.Model.Models {
    public class Hotel {
        public Hotel() {
            Offers = new HashSet<Offer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Star { get; set; }
        public int? CityId { get; set; }
        public string Description { get; set; }
        public string PhotosPaths { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}