using System;
using System.Collections.Generic;

namespace Tourismus.Model.Models {
    public class Offer {
        public Offer() {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public int HotelId { get; set; }
        public int CityId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPeople { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? MealsId { get; set; }
        public virtual City City { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual Meal Meals { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}