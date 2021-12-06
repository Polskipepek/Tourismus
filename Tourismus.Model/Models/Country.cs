using System.Collections.Generic;

namespace Tourismus.Model.Models {
    public class Country {
        public Country() {
            Cities = new HashSet<City>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}