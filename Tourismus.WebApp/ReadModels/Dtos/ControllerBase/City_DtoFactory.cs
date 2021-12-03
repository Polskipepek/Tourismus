using System.Collections.Generic;
using System.Linq;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels.Dtos.List;

namespace Tourismus.WebApp.ReadModels.Dtos.ControllerBase {
    public class City_DtoFactory {

        public static City_Dto[] BuildDtos(TourismusDbContext context, IEnumerable<City> cities) {
            return (from city in cities.ToList()
                    select new City_Dto() {
                        Id = city.Id,
                        Name = city.Name,
                        CountryName = context.Countries.FirstOrDefault(c => c.Id == city.CountryId).Name,
                    })
                    .ToArray();
        }
    }
}
