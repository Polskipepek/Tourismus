import React, { FunctionComponent, useContext, useEffect, useState } from "react";

import Resources from "../../Resources";
import { Button, Card, Col, Divider, Row, Spin } from "antd";
import { IUser_Dto, ReservationClient, Reservation_ListDto, UserClient } from "../../services/GeneratedClient";
import { IAppContext, AppContext } from "../../App";
import { EditOutlined } from "@ant-design/icons";
import Tabelka from "../OData/Tabelka";
import { IReservation_ListDto } from "../../services/ListDtos/Reservation_ListDto";
import moment from "antd/node_modules/moment";
import { EditUserModal } from "../User/EditUserModal";
import { openNotification } from "../../Helpers/NotificationHelper";

interface IUserProfilePageProps {}

export const UserProfilePage: React.FC<IUserProfilePageProps> = (props) => {
	const { user } = useContext<IAppContext>(AppContext);
	const [editModalVisible, setEditModalVisible] = useState<boolean>(false);

	const [userData, setUserData] = useState<IUser_Dto>();
	const [reservations, setReservations] = useState<Reservation_ListDto[]>([]);

	useEffect(() => {
		getUserData();
		getReservations();
	}, []);

	const getUserData = () => {
		new UserClient()
			.getUserData(user?.id ?? 2)
			.then((resp) => resp != undefined && setUserData(resp))
			.catch((err) => console.log(err.message));
	};

	const getReservations = () => {
		new ReservationClient()
			.getListReservations(user?.id ?? -1)
			.then((resp) => resp != undefined && setReservations(resp))
			.catch((err) => console.log(err.message));
	};

	const cancelReservation = (resId: number) => {
		console.log(resId);
		new ReservationClient()
			.cancelReservation(resId)
			.then(() => openNotification(Resources.Notifications.successTitle, Resources.Notifications.canceledReservation))
			.catch((err) => console.log(err.message));
		getReservations();
	};

	const reservationsColumns = [
		{
			key: "ReservationDate",
			title: Resources.ColumnTitles.ReservationDate,
			dataIndex: "reservationDate",
			render: (v: Date) => moment(v).format("MMM DD, YY - HH:mm:ss"),
		},
		{
			key: "IsPaid",
			title: Resources.ColumnTitles.IsPaid,
			dataIndex: "isPaid",
			render: (v: boolean) => (v ? "Zapłacone" : "Niezapłacone"),
		},
		{
			key: "DateFrom",
			title: Resources.ColumnTitles.DateFrom,
			dataIndex: "dateFrom",
			render: (v: Date) => moment(v).format("MMM DD, YY - HH:mm:ss"),
		},
		{
			key: "DateTo",
			title: Resources.ColumnTitles.DateTo,
			dataIndex: "dateTo",
			render: (v: Date) => moment(v).format("MMM DD, YY - HH:mm:ss"),
		},
		{
			key: "Price",
			title: Resources.ColumnTitles.Price,
			dataIndex: "price",
			render: (v: number) => `${v} PLN`,
		},
		{
			key: "NumberOfPeople",
			title: Resources.ColumnTitles.NumberOfPeople,
			dataIndex: "numberOfPeople",
		},
		{
			key: "HotelId",
			title: Resources.ColumnTitles.HotelId,
			dataIndex: "hotelId",
			render: () => <Button onClick={() => {}}>Szczegóły</Button>,
		},
		{
			key: "MealName",
			title: Resources.ColumnTitles.MealName,
			dataIndex: "mealName",
		},
		{
			key: "Id",
			width: "10%",
			title: Resources.ColumnTitles.action,
			dataIndex: "id",
			render: (v: number) => <Button onClick={(t) => cancelReservation(v)}>{Resources.Buttons.remove}</Button>,
		},
	];

	const closeEditUserModal = () => {
		setEditModalVisible(false);
		getUserData();
	};

	const filter = {
		UserId: { eq: user?.id },
	};

	return (
		<>
			<h1>{Resources.PageHeader.profilePage}</h1>

			<Spin spinning={userData == undefined}>
				<Row justify="center" align="middle" gutter={[16, 16]}>
					<Col span={6}>
						<Card title={"Imię:"}>{userData?.firstName ?? ""}</Card>
					</Col>
					<Col span={6}>
						<Card title={"Nazwisko:"}>{userData?.lastName ?? ""}</Card>
					</Col>
				</Row>
				<Row justify="center" align="middle" gutter={[16, 8]}>
					<Col span={6}>
						<Card title={"Email:"}>{userData?.email ?? ""}</Card>
					</Col>
					<Col span={6}>
						<Card title={"Numer kontaktowy:"}>{userData?.telephoneNumber ?? ""}</Card>
					</Col>
				</Row>
				<Row justify="center" align="middle" gutter={[16, 8]}>
					<Col span={8}>
						<Card title={"Ostatnie udane logowanie:"}>{userData?.lastSuccessfullyLogin?.format("MMM DD, YYYY") ?? ""}</Card>
					</Col>
					<Col span={8}>
						<Card title={"Ostatnie nieudane logowanie"}>{userData?.lastUnsuccessfullyLoginAttempt?.format("MMM DD, YYYY") ?? ""}</Card>
					</Col>
				</Row>
				<br />
				<Row justify="center" align="middle" gutter={[16, 8]}>
					<Col>
						<Button type="dashed" onClick={() => setEditModalVisible(true)}>
							<EditOutlined />
							{Resources.Buttons.edit}
						</Button>
					</Col>
				</Row>
			</Spin>
			<Divider type="horizontal" />
			<Spin spinning={userData == undefined}>
				<Tabelka key={"reservations-table"} columns={reservationsColumns} data={reservations} {...props} />
			</Spin>

			{userData && <EditUserModal modalVisible={editModalVisible} closeModal={() => closeEditUserModal()} userDto={userData} />}
		</>
	);
};

export default UserProfilePage;
