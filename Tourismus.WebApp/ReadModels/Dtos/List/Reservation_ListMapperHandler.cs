using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels._Infrastructure.Mappers;

namespace Tourismus.WebApp.ReadModels.Dtos.List {
    public class Reservation_ListMapperHandler : IHandleMapper<Reservation, Reservation_ListDto> {
        public async Task<List<Reservation_ListDto>> Handle(IQueryable<Reservation> entities, CancellationToken token) {
            return await entities.Select(x => new Reservation_ListDto {
                Id = x.Id,
                DateFrom = x.Offer.DateFrom,
                DateTo = x.Offer.DateTo,
                ReservationDate = x.ReservationDate,
                IsPaid = x.IsPaid,
                HotelId = x.Offer.Hotel.Id,
                MealName = x.Offer.Meal.Name,
                NumberOfPeople = x.Offer.NumberOfPeople,
                Price = x.Offer.Price,
                UserId=x.User.Id,
            }).ToListAsync(cancellationToken: token);
        }
    }
}
