import "./city.css";

import { Button, Modal } from "antd";

import { CheckCircleTwoTone } from "@ant-design/icons";

import { IModalComponentProps } from "../../_Infrastructure/Modals/IModalComponentProps";
import Resources from "../../Resources";
import { AddOfferForm } from "./AddOfferForm";
import { CityClient, City_Dto, CountryClient, HotelClient, Hotel_Dto, MealClient, Meal_Dto } from "../../services/GeneratedClient";
import { useEffect, useState } from "react";

interface IAddOfferModalProps extends IModalComponentProps {
	modalVisible: boolean;
}

export const AddOfferModal: React.FunctionComponent<IAddOfferModalProps> = (props) => {
	const [cities, setCities] = useState<City_Dto[]>([]);
	const [hotels, setHotels] = useState<Hotel_Dto[]>([]);
	const [meals, setMeals] = useState<Meal_Dto[]>([]);

	useEffect(() => {
		new CityClient().getCities().then((resp) => {
			if (resp != null && (resp as City_Dto[])) {
				setCities(resp);
			}
		});

		new HotelClient().getHotels().then((resp) => {
			if (resp != null && (resp as Hotel_Dto[])) {
				setHotels(resp);
			}
		});

		new MealClient().getMeals().then((resp) => {
			if (resp != null && (resp as Meal_Dto[])) {
				setMeals(resp);
			}
		});
	}, []);

	return (
		<>
			<Modal
				className="addOffer-modal"
				title={Resources.ModalHeader.AddOffer}
				centered
				visible={props.modalVisible}
				onCancel={() => props.closeModal()}
				destroyOnClose
				footer={[
					<Button form="addOffer-form" key="submit" htmlType="submit" type="primary">
						<CheckCircleTwoTone />
					</Button>,
				]}>
				<AddOfferForm cities={cities} hotels={hotels} meals={meals} {...props} />
			</Modal>
		</>
	);
};
