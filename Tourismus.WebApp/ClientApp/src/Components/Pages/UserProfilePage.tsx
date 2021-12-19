import React, { FunctionComponent, useEffect, useState } from "react";

import { ODataSingleType } from "../../_Infrastructure/OData/Singles/ODataSingleType";
import Resources from "../../Resources";
import { ODataSingle } from "../../_Infrastructure/OData/Singles/ODataSingle";
import { IUser_DetailsDto } from "../../services/SingleDto/User_DetailsDto";
import { Col, Row, Spin } from "antd";
import { IUser } from "../../services/GeneratedClient";
//import Profile from "../OData/Profile";

interface IUserProfilePageProps {
	user: IUser;
}

export const UserProfilePage: FunctionComponent<IUserProfilePageProps> = (props) => {
	const [userData, setUserData] = useState<IUser_DetailsDto>();

	const filter = {
		Id: { eq: props.user?.id ?? 2 },
	};

	useEffect(() => {}, [userData]);

	return (
		<>
			<h1>{Resources.PageHeader.profilePage}</h1>
			<ODataSingle {...props} oDataSingleType={ODataSingleType.UserDetail} filter={filter} render={(data: IUser_DetailsDto) => setUserData(data)} />

			<Spin spinning={userData == undefined}>
				<Row justify="space-around" align="middle">
					<Col span={4}>{userData?.firstName}</Col>
					<Col span={4}>{userData?.lastName}</Col>
				</Row>
				<Row justify="space-around" align="middle">
					<Col span={4}>{userData?.email}</Col>
					<Col span={4}>{userData?.telephoneNumber}</Col>
				</Row>
				<Row justify="space-around" align="middle">
					<Col span={4}>{userData?.lastSuccessfullyLogin}</Col>
					<Col span={4}>{userData?.lastUnsuccessfullyLoginAttempt}</Col>
				</Row>
			</Spin>
		</>
	);
};

export default UserProfilePage;
