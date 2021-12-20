


export interface IReservation_ListDto {
	
		Id: number;
		ReservationDate: Date;
		IsPaid: boolean;
		DateFrom: Date;
		DateTo: Date;
		Price: number;
		NumberOfPeople: number;
		HotelId: number;
		MealName: string;
}
