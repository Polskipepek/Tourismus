using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tourismus.Model.Models {
    public class Offer : EntityBase {
        public Offer() {
            Reservations = new HashSet<Reservation>();
        }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPeople { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual City City { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}