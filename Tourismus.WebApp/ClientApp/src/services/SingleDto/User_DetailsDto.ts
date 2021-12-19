


export interface IUser_DetailsDto {
	
		firstName: string;
		lastName: string;
		telephoneNumber: string;
		email: string;
		accountCreationDate: Date;
		lastSuccessfullyLogin?: Date;
		lastUnsuccessfullyLoginAttempt?: Date;
}
