using System;

namespace Tourismus.WebApp.ReadModels.Dtos.Single {
    public class User_DetailsDto {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public DateTime? LastSuccessfullyLogin { get; set; }
        public DateTime? LastUnsuccessfullyLoginAttempt { get; set; }
    }
}
