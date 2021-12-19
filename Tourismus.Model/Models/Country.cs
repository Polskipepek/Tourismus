using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tourismus.Model.Models {
    public class Country : EntityBase {
        public Country() {
            Cities = new HashSet<City>();
        }

        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}