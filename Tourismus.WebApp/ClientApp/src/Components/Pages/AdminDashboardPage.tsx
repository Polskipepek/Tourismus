import { CheckOutlined, CloseOutlined } from "@ant-design/icons";
import { Button, Divider, Modal, Spin, Tabs, Tooltip } from "antd";
import { useEffect, useState } from "react";
import Resources from "../../Resources";
import { CityClient, City_Dto, Country, CountryClient, Country_Dto, HotelClient, Hotel_Dto, MealClient, Meal_Dto, OfferClient, OfferList_Dto } from "../../services/GeneratedClient";
import { AddCityModal } from "../City/AddCityModal";
import { AddCountryModal } from "../Country/AddCountryModal";
import { AddHotelModal } from "../Hotel/AddHotelModal";
import { AddMealModal } from "../Meal/AddMealModal";
import Tabelka from "../OData/Tabelka";
import { AddOfferModal } from "../Offer/AddOfferModal";
interface IAdminDashboardPageProps {}

const AdminDashboardPage: React.FC<IAdminDashboardPageProps> = (props) => {
	const [cities, setCities] = useState<City_Dto[]>([]);
	const [countries, setCountries] = useState<Country_Dto[]>([]);
	const [meals, setMeals] = useState<Meal_Dto[]>([]);
	const [offers, setOffers] = useState<OfferList_Dto[]>([]);
	const [hotels, setHotels] = useState<Hotel_Dto[]>([]);

	const [addCityModalVisible, setAddCityModalVisible] = useState<boolean>(false);
	const [addCountryModalVisible, setAddCountryModalVisible] = useState<boolean>(false);
	const [addMealModalVisible, setAddMealModalVisible] = useState<boolean>(false);
	const [addOfferModalVisible, setAddOfferModalVisible] = useState<boolean>(false);
	const [addHotelModalVisible, setAddHotelModalVisible] = useState<boolean>(false);

	const { TabPane } = Tabs;

	/* 	useEffect(() => {
		getCities();
		getCountries();
		getMeals();
	}, []); */

	useEffect(() => {
		getCities();
	}, [, addCityModalVisible]);

	useEffect(() => {
		getCountries();
	}, [, addCountryModalVisible]);

	useEffect(() => {
		getMeals();
	}, [, addMealModalVisible]);
	useEffect(() => {
		getOffers();
	}, [, addOfferModalVisible]);

	useEffect(() => {
		getHotels();
	}, [, addHotelModalVisible]);

	const getCities = () => {
		new CityClient().getCities().then((resp) => {
			if (resp != null && (resp as City_Dto[])) {
				setCities(resp);
			}
		});
	};

	const getCountries = () => {
		new CountryClient().getCountries().then((resp) => {
			if (resp != null && (resp as Country_Dto[])) {
				setCountries(resp);
			}
		});
	};

	const getMeals = () => {
		new MealClient().getMeals().then((resp) => {
			if (resp != null && (resp as Meal_Dto[])) {
				setMeals(resp);
			}
		});
	};

	const getOffers = () => {
		new OfferClient().getListOffers().then((resp) => {
			if (resp != null && (resp as OfferList_Dto[])) {
				setOffers(resp);
			}
		});
	};

	const getHotels = () => {
		new HotelClient().getHotels().then((resp) => {
			if (resp != null && (resp as Hotel_Dto[])) {
				setHotels(resp);
			}
		});
	};
	const offersColumns = [
		{
			key: "name",
			title: Resources.ColumnTitles.offer,
			dataIndex: "name",
			sort: (a: OfferList_Dto, b: OfferList_Dto) => a.name!.localeCompare(b.name!),
		},
		{
			key: "stars",
			title: Resources.ColumnTitles.stars,
			dataIndex: "stars",
			sort: (a: OfferList_Dto, b: OfferList_Dto) => a.stars - b.stars,
		},
		{
			key: "cityName",
			title: Resources.ColumnTitles.city,
			dataIndex: "cityName",
			sort: (a: OfferList_Dto, b: OfferList_Dto) => a.cityName!.localeCompare(b.cityName!),
		},
		{
			key: "countryName",
			title: Resources.ColumnTitles.country,
			dataIndex: "countryName",
			sort: (a: OfferList_Dto, b: OfferList_Dto) => a.countryName!.localeCompare(b.countryName!),
		},
		{
			width: "20%",
			title: Resources.ColumnTitles.action,
			render: (v: OfferList_Dto) => <Button onClick={() => onClickRemoveCountry(v.id)}>{Resources.Buttons.remove}</Button>,
		},
	];

	const hotelsColumns = [
		{
			key: "name",
			title: Resources.ColumnTitles.hotel,
			dataIndex: "name",
			sort: (a: Hotel_Dto, b: Hotel_Dto) => a.name!.localeCompare(b.name!),
		},
		{
			width: "20%",
			title: Resources.ColumnTitles.action,
			render: (v: Hotel_Dto) => <Button onClick={() => onClickRemoveCountry(v.id)}>{Resources.Buttons.remove}</Button>,
		},
	];

	const citiesColumns = [
		{
			key: "name",
			title: Resources.ColumnTitles.city,
			dataIndex: "name",
			sort: (a: City_Dto, b: City_Dto) => a.name!.localeCompare(b.name!),
		},
		{
			key: "countryName",
			title: Resources.ColumnTitles.country,
			dataIndex: "countryName",
			sort: (a: City_Dto, b: City_Dto) => a.countryName!.localeCompare(b.countryName!),
		},
		{
			key: "isAirport",
			title: Resources.ColumnTitles.isAirport,
			dataIndex: "isAirport",
			render: (v: boolean) => (v == true ? <CheckOutlined /> : <CloseOutlined />),
		},
		{
			width: "20%",
			title: Resources.ColumnTitles.action,
			render: (v: City_Dto) => <Button onClick={() => onClickRemoveCity(v.id)}>{Resources.Buttons.remove}</Button>,
		},
	];

	const countriesColumns = [
		{
			key: "name",
			title: Resources.ColumnTitles.country,
			dataIndex: "name",
			sort: (a: Country_Dto, b: Country_Dto) => a.name!.localeCompare(b.name!),
		},
		{
			width: "20%",
			title: Resources.ColumnTitles.action,
			render: (v: Country_Dto) => <Button onClick={() => onClickRemoveCountry(v.id)}>{Resources.Buttons.remove}</Button>,
		},
	];

	const mealsColumns = [
		{
			key: "name",
			title: Resources.ColumnTitles.meal,
			dataIndex: "name",
			sort: (a: Meal_Dto, b: Meal_Dto) => a.name!.localeCompare(b.name!),
		},
		{
			width: "20%",
			title: Resources.ColumnTitles.action,
			render: (v: Meal_Dto) => <Button onClick={() => onClickRemoveMeal(v.id)}>{Resources.Buttons.remove}</Button>,
		},
	];

	const onClickRemoveCountry = (id: number) => {
		new CountryClient().removeCountry(id).then((resp) => {
			if (resp.status == 200) {
				getCountries();
				getCities();
			}
		});
	};

	const onClickRemoveCity = (id: number) => {
		new CityClient().removeCity(id).then((resp) => {
			if (resp.status == 200) {
				getCountries();
				getCities();
			}
		});
	};

	const onClickRemoveMeal = (id: number) => {
		new MealClient().removeMeal(id).then((resp) => {
			if (resp.status == 200) {
				getMeals();
			}
		});
	};

	return (
		<>
			<Tabs defaultActiveKey={Resources.BusinessNames.offers}>
				<TabPane tab={Resources.BusinessNames.offers} key={Resources.BusinessNames.offers}>
					<Button style={{ backgroundColor: "#aaa" }} key={"AddOfferBtn"} type="primary" title={Resources.Buttons.addOffer} onClick={() => setAddOfferModalVisible(true)}>
						{Resources.Buttons.addOffer}
					</Button>
					<br /> <br />
					<Spin spinning={offers.length == 0}>
						<Tabelka data={offers} columns={offersColumns} />
					</Spin>
				</TabPane>
				<TabPane tab={Resources.BusinessNames.cities} key={Resources.BusinessNames.cities}>
					<Button style={{ backgroundColor: "#aaa" }} key={"AddCityBtn"} type="primary" onClick={() => setAddCityModalVisible(true)}>
						{Resources.Buttons.addCity}
					</Button>
					<br /> <br />
					<Spin spinning={cities.length == 0}>
						<Tabelka data={cities} columns={citiesColumns} />
					</Spin>
				</TabPane>
				<TabPane tab={Resources.BusinessNames.countries} key={Resources.BusinessNames.countries}>
					<Button style={{ backgroundColor: "#aaa" }} key={"AddCountryBtn"} type="primary" onClick={() => setAddCountryModalVisible(true)}>
						{Resources.Buttons.addCountry}
					</Button>
					<br /> <br />
					<Spin spinning={countries.length == 0}>
						<Tabelka data={countries} columns={countriesColumns} />
					</Spin>
				</TabPane>
				<TabPane tab={Resources.BusinessNames.meals} key={Resources.BusinessNames.meals}>
					<Button style={{ backgroundColor: "#aaa" }} key={"AddMealBtn"} type="primary" onClick={() => setAddMealModalVisible(true)}>
						{Resources.Buttons.addMeal}
					</Button>
					<br /> <br />
					<Spin spinning={meals.length == 0}></Spin>
					<Tabelka data={meals} columns={mealsColumns} />
				</TabPane>
				<TabPane tab={Resources.BusinessNames.hotels} key={Resources.BusinessNames.hotels}>
					<Button style={{ backgroundColor: "#aaa" }} key={"AddHotelBtn"} type="primary" onClick={() => setAddHotelModalVisible(true)}>
						{Resources.Buttons.addHotel}
					</Button>
					<br /> <br />
					<Spin spinning={hotels.length == 0}>
						<Tabelka data={hotels} columns={hotelsColumns} />
					</Spin>
				</TabPane>
			</Tabs>

			<AddCountryModal modalVisible={addCountryModalVisible} closeModal={() => setAddCountryModalVisible(false)} />
			<AddCityModal modalVisible={addCityModalVisible} closeModal={() => setAddCityModalVisible(false)} countriesToAddCity={countries} />
			<AddMealModal modalVisible={addMealModalVisible} closeModal={() => setAddMealModalVisible(false)} />
			<AddOfferModal modalVisible={addOfferModalVisible} closeModal={() => setAddOfferModalVisible(false)} />
			<AddHotelModal modalVisible={addHotelModalVisible} closeModal={() => setAddHotelModalVisible(false)} />
		</>
	);
};

export default AdminDashboardPage;
