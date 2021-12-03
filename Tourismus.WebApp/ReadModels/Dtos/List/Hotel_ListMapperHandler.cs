using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels._Infrastructure.Mappers;

namespace Tourismus.WebApp.ReadModels.Dtos.List {
    public class Hotel_ListMapperHandler : IHandleMapper<Hotel, Hotel_ListDto> {
        public async Task<List<Hotel_ListDto>> Handle(IQueryable<Hotel> entities, CancellationToken token) {
            return await entities.Select(x => new Hotel_ListDto {
                Id = x.Id,
                CityName = x.Name,
                Name = x.Name,
                CountryName = x.City.IdNavigation.Name,
                Star = x.Star ?? 0,
            }).ToListAsync(cancellationToken: token);
        }


    }
}
