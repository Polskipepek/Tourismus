import { CheckOutlined, CloseOutlined } from "@ant-design/icons";
import { Button, Divider, Modal, Tooltip } from "antd";
import { useEffect, useState } from "react";
import Resources from "../../Resources";
import { CityClient, City_Dto, Country, CountryClient, Country_Dto, MealClient, Meal_Dto } from "../../services/GeneratedClient";
import { AddCityModal } from "../City/AddCityModal";
import { AddCountryModal } from "../Country/AddCountryModal";
import { AddMealModal } from "../Meal/AddMealModal";
import Tabelka from "../OData/Tabelka";
interface IAdminDashboardPageProps {}

const AdminDashboardPage: React.FC<IAdminDashboardPageProps> = (props) => {
	const [cities, setCities] = useState<City_Dto[]>([]);
	const [countries, setCountries] = useState<Country_Dto[]>([]);
	const [meals, setMeals] = useState<Meal_Dto[]>([]);

	const [addCityModalVisible, setAddCityModalVisible] = useState<boolean>(false);
	const [addCountryModalVisible, setAddCountryModalVisible] = useState<boolean>(false);
	const [addMealModalVisible, setAddMealModalVisible] = useState<boolean>(false);

	useEffect(() => {
		getCities();
		getCountries();
		getMeals();
	}, []);

	useEffect(() => {
		getCities();
		getCountries();
	}, [addCountryModalVisible, addCityModalVisible]);

	useEffect(() => {
		getMeals();
	}, [addMealModalVisible]);
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
			<Tabelka data={cities} columns={citiesColumns} title={Resources.ColumnTitles.city} />
			<Button style={{ backgroundColor: "#aaa" }} key={"AddCityBtn"} type="primary" title={Resources.Buttons.addCity} onClick={() => setAddCityModalVisible(true)}>
				{Resources.Buttons.addCity}
			</Button>
			<Divider type="horizontal" />

			<Tabelka data={countries} columns={countriesColumns} title={Resources.ColumnTitles.country} />
			<Button style={{ backgroundColor: "#aaa" }} key={"AddCountryBtn"} type="primary" title={Resources.Buttons.addCountry} onClick={() => setAddCountryModalVisible(true)}>
				{Resources.Buttons.addCountry}
			</Button>
			<Divider type="horizontal" />

			<Tabelka data={meals} columns={mealsColumns} title={Resources.ColumnTitles.meal} />
			<Button style={{ backgroundColor: "#aaa" }} key={"AddMealBtn"} type="primary" title={Resources.Buttons.addMeal} onClick={() => setAddMealModalVisible(true)}>
				{Resources.Buttons.addMeal}
			</Button>

			<AddCountryModal modalVisible={addCountryModalVisible} closeModal={() => setAddCountryModalVisible(false)} />
			<AddCityModal modalVisible={addCityModalVisible} closeModal={() => setAddCityModalVisible(false)} countriesToAddCity={countries} />
			<AddMealModal modalVisible={addMealModalVisible} closeModal={() => setAddMealModalVisible(false)} />
		</>
	);
};

export default AdminDashboardPage;
