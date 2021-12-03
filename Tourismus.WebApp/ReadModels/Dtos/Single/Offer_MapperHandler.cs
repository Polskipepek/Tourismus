using System.Linq;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels._Infrastructure.Mappers;

namespace Tourismus.WebApp.ReadModels.Dtos.Single {
    public class Offer_MapperHandler : ISingleHandleMapper<Offer, Offer_DetailsDto> {
        public Offer_DetailsDto Handle(Offer x) {
            return new Offer_DetailsDto {
                Id = x.Id,
                DateFrom = x.DateFrom,
                DateTo = x.DateTo,
                CityName = x.City.Name,
                CountryName = x.City.IdNavigation.Name,
                Description = x.Description,
                MealType = x.Meals.Name,
                Price = x.Price,
                Stars = x.Hotel.Star ?? 0,
                NumberOfPeople = x.NumberOfPeople,
                PhotoPaths=x.Hotel.PhotosPaths,
            };
        }
    }
}
