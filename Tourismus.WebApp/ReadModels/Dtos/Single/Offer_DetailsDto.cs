using System;

namespace Tourismus.WebApp.ReadModels.Dtos.Single {
    public class Offer_DetailsDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPeople { get; set; }
        public string PhotoPaths { get; set; }
        public string Description { get; set; }
        public string MealType { get; set; }

    }
}
