using System.Collections.Generic;
using System.Linq;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels.Dtos.List;

namespace Tourismus.WebApp.ReadModels.Dtos.ControllerBase {
    public class OfferList_DtoFactory {

        public static OfferList_Dto[] BuildDtos(TourismusDbContext context, IEnumerable<Offer> offers) {
            return (from offer in offers.ToList()
                    let name = context.Hotels.FirstOrDefault(h => h.Id == offer.Id)?.Name
                    select new OfferList_Dto() {
                        Id = offer.Id,
                        CityName = offer.City.Name,
                        CountryName = offer.City.Country.Name,
                        DateFrom = offer.DateFrom,
                        DateTo = offer.DateTo,
                        MealType = offer.Meal.Name,
                        Name = name,
                        NumberOfPeople = offer.NumberOfPeople,
                        Price = offer.Price,
                        Stars = offer.Hotel.Star,

                    })
                    .ToArray();
        }
    }
}
