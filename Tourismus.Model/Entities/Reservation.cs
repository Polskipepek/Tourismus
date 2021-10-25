using System;
using Tourismus.Model.Configuration._Infrastructure;

namespace Api.Model.Database {
    public partial class Reservation : ModelBase {
        public int OfferId { get; set; }
        public int UserId { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool IsPaid { get; set; }

        public virtual Offer Offer { get; set; }
        public virtual User User { get; set; }
    }
}
