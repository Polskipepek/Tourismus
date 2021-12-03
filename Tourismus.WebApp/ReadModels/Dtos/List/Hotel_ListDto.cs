using Tourismus.Model.Models;

namespace Tourismus.WebApp.ReadModels.Dtos.List {
    public class Hotel_ListDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Star { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
    }
}
