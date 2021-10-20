using NetTopologySuite.Geometries;
using System.Collections.Generic;

#nullable disable

namespace Api.Model.Database {
    public partial class City {
        public City() {
            Offers = new HashSet<Offer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Geometry Position { get; set; }
        public bool IsAirport { get; set; }
        public virtual Country IdNavigation { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
