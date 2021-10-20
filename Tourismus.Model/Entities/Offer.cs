using System;
using System.Collections.Generic;

namespace Api.Model.Database {
    public partial class Offer {
        public Offer() {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public int CityId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPeople { get; set; }
        public string PhotoPaths { get; set; }
        public string Description { get; set; }
        public int? MealsId { get; set; }

        public virtual City City { get; set; }
        public virtual Meal Meals { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
