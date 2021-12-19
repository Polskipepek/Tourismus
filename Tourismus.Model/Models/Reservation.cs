using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tourismus.Model.Models  {
    public class Reservation : EntityBase {
        public DateTime ReservationDate { get; set; }
        public bool IsPaid { get; set; }

        public virtual Offer Offer { get; set; }
        public virtual User User { get; set; }
    }
}