using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels._Infrastructure.Mappers;

namespace Tourismus.WebApp.ReadModels.Dtos.Single {
    public class User_MapperHandler : ISingleHandleMapper<User, User_DetailsDto> {
        public User_DetailsDto Handle(User x) {
            return new User_DetailsDto {
                FirstName = x.FirstName,
                LastName = x.LastName,
                AccountCreationDate = x.AccountCreationDate,
                Email = x.Email,
                LastSuccessfullyLogin = x.LastSuccessfullyLogin,
                LastUnsuccessfullyLoginAttempt = x.LastUnsuccessfullyLoginAttempt,
                TelephoneNumber = x.TelephoneNumber,
            };
        }
    }
}
