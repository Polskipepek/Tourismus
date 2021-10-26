import React, { FunctionComponent } from "react";

import { ODataSingleType } from "../../_Infrastructure/OData/Singles/ODataSingleType";
import Resources from "../../Resources";
//import Profile from "../OData/Profile";

interface IUserProfilePageProps {}

export const UserProfilePage: FunctionComponent<IUserProfilePageProps> = (props) => {
	const filter = {
		Id: { eq: 3 },
	};

	return (
		<>
			<h1>{Resources.PageHeader.profilePage}</h1>
			{/* 	<ODataSingle {...props} oDataSingleType={ODataSingleType.CustomerDetails} filter={filter} render={(data: ICustomerDetails_Dto) => <Profile {...props} {...data} />} />*/}
		</>
	);
};

export default UserProfilePage;
