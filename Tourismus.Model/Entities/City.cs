using NetTopologySuite.Geometries;
using System.Collections.Generic;
using Tourismus.Model.Configuration._Infrastructure;

namespace Api.Model.Database {
    public partial class City : ModelBase {
        public City() {
            Offers = new HashSet<Offer>();
        }

        public string Name { get; set; }
        public int CountryId { get; set; }
        public Geometry Position { get; set; }
        public bool IsAirport { get; set; }
        public virtual Country IdNavigation { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
