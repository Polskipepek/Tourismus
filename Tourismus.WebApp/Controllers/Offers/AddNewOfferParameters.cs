using System;

namespace Tourismus.WebApp.Controllers.Offers {
    public class AddNewOfferParameters {
        public int HotelId { get; set; }
        public int CityId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPeople { get; set; }
        public string PhotoPaths { get; set; }
        public string Description { get; set; }
        public int? MealsId { get; set; }
    }
}
