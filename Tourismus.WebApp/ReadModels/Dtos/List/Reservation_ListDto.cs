using System;

namespace Tourismus.WebApp.ReadModels.Dtos.List {
    public class Reservation_ListDto {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPeople { get; set; }
        public int HotelId { get; set; }
        public string MealName{ get; set; }

    }
}
