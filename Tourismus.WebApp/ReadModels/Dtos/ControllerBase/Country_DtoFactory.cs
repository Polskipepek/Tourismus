using System.Collections.Generic;
using System.Linq;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels.Dtos.List;

namespace Tourismus.WebApp.ReadModels.Dtos.ControllerBase {
    public class Country_DtoFactory {

        public static Country_Dto[] BuildDtos(TourismusDbContext context, IEnumerable<Country> countries) {
            return (from country in countries.ToList()
                    select new Country_Dto() {
                        Id = country.Id,
                        Name = country.Name,
                    })
                    .ToArray();
        }
    }
}
