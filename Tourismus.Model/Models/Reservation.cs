using System;


namespace Tourismus.Model.Models {
    public class Reservation {
        public int Id { get; set; }
        public int OfferId { get; set; }
        public int UserId { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool IsPaid { get; set; }

        public virtual Offer Offer { get; set; }
        public virtual User User { get; set; }
    }
}