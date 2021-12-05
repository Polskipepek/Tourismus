﻿using System;
using System.Collections.Generic;


namespace Tourismus.Model.Models {
    public class User {
        public User() {
            Reservations = new HashSet<Reservation>();
            UserCredentials = new HashSet<UserCredential>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<UserCredential> UserCredentials { get; set; }
    }
}