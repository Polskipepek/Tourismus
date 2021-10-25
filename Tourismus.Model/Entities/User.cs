using System;
using System.Collections.Generic;
using Tourismus.Model.Configuration._Infrastructure;

namespace Api.Model.Database {
    public partial class User : ModelBase {
        public User() {
            Reservationsxd = new HashSet<Reservation>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<Reservation> Reservationsxd { get; set; }
    }
}
