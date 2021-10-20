using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Model.Database {
    public partial class User {
        public User() {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
