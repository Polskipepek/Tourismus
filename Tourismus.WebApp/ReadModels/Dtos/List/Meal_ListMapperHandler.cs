using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels._Infrastructure.Mappers;

namespace Tourismus.WebApp.ReadModels.Dtos.List {
    public class Meal_ListMapperHandler : IHandleMapper<Meal, Meal_ListDto> {
        public async Task<List<Meal_ListDto>> Handle(IQueryable<Meal> entities, CancellationToken token) {
            return await entities.Select(x => new Meal_ListDto {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync(cancellationToken: token);
        }
    }
}
