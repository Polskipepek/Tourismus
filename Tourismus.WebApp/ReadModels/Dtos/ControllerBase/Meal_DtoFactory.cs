using System.Collections.Generic;
using System.Linq;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels.Dtos.List;

namespace Tourismus.WebApp.ReadModels.Dtos.ControllerBase {
    public class Meal_DtoFactory {

        public static Meal_Dto[] BuildDtos(TourismusDbContext context, IEnumerable<Meal> meals) {
            return (from country in meals.ToList()
                    select new Meal_Dto() {
                        Id = country.Id,
                        Name = country.Name,
                    })
                    .ToArray();
        }
    }
}
