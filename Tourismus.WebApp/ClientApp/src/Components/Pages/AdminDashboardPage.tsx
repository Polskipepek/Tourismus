import { Button, Divider, Modal } from "antd";
import { useEffect, useState } from "react";
import Resources from "../../Resources";
import { CityClient, City_Dto, CountryClient, Country_Dto } from "../../services/GeneratedClient";
import { AddCityModal } from "../City/AddCityModal";
import { AddCountryModal } from "../Country/AddCountryModal";
import Tabelka from "../OData/Tabelka";
interface IAdminDashboardPageProps {}

const AdminDashboardPage: React.FC<IAdminDashboardPageProps> = (props) => {
	const [cities, setCities] = useState<City_Dto[]>([]);
	const [countries, setCountries] = useState<Country_Dto[]>([]);

	const [addCityModalVisible, setAddCityModalVisible] = useState<boolean>(false);
	const [addCountryModalVisible, setAddCountryModalVisible] = useState<boolean>(false);

	useEffect(() => {
		getCities();
		getCountries();
	}, []);

	useEffect(() => {
		getCities();
		getCountries();
	}, [addCountryModalVisible, addCityModalVisible]);

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

	const citiesColumns = [
		{
			key: "name",
			title: "Name",
			dataIndex: "name",
			sorter: true,
			sort: (a: City_Dto, b: City_Dto) => a.name!.localeCompare(b.name!),
		},
		{
			key: "countryName",
			title: "Country name",
			dataIndex: "countryName",
			sorter: true,
		},
		{
			width: "20%",
			title: "Akcja",
			render: (v: City_Dto) => <Button onClick={() => onClickRemoveCity(v.id)}>{Resources.Buttons.remove}</Button>,
		},
	];

	const countriesColumns = [
		{
			key: "name",
			title: "Name",
			dataIndex: "name",
			sorter: true,
		},
		{
			width: "20%",
			title: "Akcja",
			render: (v: Country_Dto) => <Button onClick={() => onClickRemoveCountry(v.id)}>{Resources.Buttons.remove}</Button>,
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

	return (
		<>
			<Tabelka data={cities} columns={citiesColumns} title="Cities" />
			<Button style={{ backgroundColor: "#aaa" }} key={"AddCityBtn"} type="primary" title="Add City" onClick={() => setAddCityModalVisible(true)}>
				{Resources.Buttons.addCity}
			</Button>
			<Divider type="horizontal" />
			<Tabelka data={countries} columns={countriesColumns} title="Countries" />
			<Button style={{ backgroundColor: "#aaa" }} key={"AddCountryBtn"} type="primary" title="Add Country" onClick={() => setAddCountryModalVisible(true)}>
				{Resources.Buttons.addCountry}
			</Button>
			<Divider type="horizontal" />

			<AddCountryModal modalVisible={addCountryModalVisible} closeModal={() => setAddCountryModalVisible(false)} />
			<AddCityModal modalVisible={addCityModalVisible} closeModal={() => setAddCityModalVisible(false)} countriesToAddCity={countries} />
		</>
	);
};

export default AdminDashboardPage;
