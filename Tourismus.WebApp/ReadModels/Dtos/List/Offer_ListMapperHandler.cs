using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels._Infrastructure.Mappers;

namespace Tourismus.WebApp.ReadModels.Dtos.List {
    public class Offer_ListMapperHandler : IHandleMapper<Offer, Offer_ListDto> {
        public async Task<List<Offer_ListDto>> Handle(IQueryable<Offer> entities, CancellationToken token) {
            return await entities.Select(x => new Offer_ListDto {
                Id = x.Id,
                DateFrom = x.DateFrom,
                DateTo = x.DateTo,
                CityName = x.City.Name,
                CountryName = x.City.Country.Name,
                Description = x.Description,
                MealType = x.Meals.Name,
                Price = x.Price,
                Stars = x.Hotel.Star ?? 0,
                NumberOfPeople = x.NumberOfPeople,
            }).ToListAsync(cancellationToken: token);
        }
    }
}
