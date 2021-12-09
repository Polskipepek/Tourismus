using System;
using System.Collections.Generic;


namespace Tourismus.Model.Models {
    public class User {
        public User() {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public DateTime LastSuccessfullyLogin { get; set; }
        public DateTime LastUnsuccessfullyLoginAttempt { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}