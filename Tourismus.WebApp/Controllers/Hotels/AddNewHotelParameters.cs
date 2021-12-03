namespace Tourismus.WebApp.Controllers.Hotels {
    public class AddNewHotelParameters {
        public string Name { get; set; }
        public int Star { get; set; }
        public int? CityId { get; set; }
        public string Description { get; set; }
        public string PhotosPaths { get; set; }
    }
}
