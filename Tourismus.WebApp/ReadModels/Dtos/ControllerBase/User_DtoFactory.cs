using System.Linq;
using Tourismus.Model.Models;

namespace Tourismus.WebApp.ReadModels.Dtos.Single {
    public class User_DtoFactory {
        public static User_Dto BuildDtos(TourismusDbContext context, User user) {
            return new User_Dto {
                FirstName = user.FirstName,
                LastName = user.LastName,
                AccountCreationDate = user.AccountCreationDate,
                Email = user.Email,
                LastSuccessfullyLogin = user.LastSuccessfullyLogin,
                LastUnsuccessfullyLoginAttempt = user.LastUnsuccessfullyLoginAttempt,
                TelephoneNumber = user.TelephoneNumber,
                Reservations = context.Reservations.Where(r => r.User.Id == user.Id).ToArray(),
            };
        }
    }
}
