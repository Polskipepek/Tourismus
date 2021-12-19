using System.Collections.Generic;
using System.Linq;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels.Dtos.List;

namespace Tourismus.WebApp.ReadModels.Dtos.ControllerBase {
    public class Hotel_DtoFactory {

        public static Hotel_Dto[] BuildDtos(TourismusDbContext context, IEnumerable<Hotel> hotels) {
            return (from hotel in hotels.ToList()
                    select new Hotel_Dto() {
                        Id = hotel.Id,
                        Name = hotel.Name,
                        CityName=hotel.City?.Name ?? "Błąd",
                        Description = hotel.Description,
                        Star=hotel.Star,
                    })
                    .ToArray();
        }
    }
}
