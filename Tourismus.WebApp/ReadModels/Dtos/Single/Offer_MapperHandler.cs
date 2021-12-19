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
                CountryName = x.City.Country.Name,
                Description = x.Description,
                MealType = x.Meal.Name,
                Price = x.Price,
                Stars = x.Hotel.Star,
                NumberOfPeople = x.NumberOfPeople,
                PhotoPaths = x.Hotel.PhotosPaths,
                Name = x.Name,
            };
        }
    }
}
