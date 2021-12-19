using System.Collections.Generic;
using System.Linq;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels.Dtos.List;

namespace Tourismus.WebApp.ReadModels.Dtos.ControllerBase {
    public class City_DtoFactory {

        public static City_Dto[] BuildDtos(IEnumerable<City> cities) {
            return (from city in cities.ToArray()
                    select new City_Dto() {
                        Id = city.Id,
                        Name = city.Name,
                        CountryName = city.Country.Name,
                        IsAirport = city.IsAirport,
                    })
                    .ToArray();
        }
    }
}
