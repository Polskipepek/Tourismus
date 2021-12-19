import { Spin, Image } from "antd";
import { FunctionComponent, useEffect, useState } from "react";

import { OfferClient, OfferList_Dto } from "../../services/GeneratedClient";
import { starOptions } from "../Hotel/AddHotelForm";

import { AddOfferModal } from "../Offer/AddOfferModal";
import OfferModal from "../Offer/OfferModal";

interface IHomePageProps {}

export const HomePage: FunctionComponent<IHomePageProps> = (props) => {
	const [offers, setOffers] = useState<OfferList_Dto[]>([]);
	const [addOfferModalVisible, setAddOfferModalVisible] = useState<boolean>(false);
	const [selectedOffer, setSelectedOffer] = useState<OfferList_Dto | undefined>(undefined);

	useEffect(() => {
		getOffers();
	}, []);

	useEffect(() => {}, [offers]);

	const getOffers = () => {
		new OfferClient().getListOffers().then((resp) => {
			if (resp != null && (resp as OfferList_Dto[])) {
				setOffers(resp);
			}
		});
	};

	return (
		<>
			<Spin spinning={offers.length == 0}>
				<div className="item-container">
					{offers.map((offer) => (
						<div className="card" key={offer.id}>
							<a className="fill-div" onClick={() => setSelectedOffer(offer)} />
							<h3>{`${offer.name}`}</h3>
							<p>{`Od ${offer.dateFrom.format("MMM DD, YYYY")} do  ${offer.dateTo.format("MMM DD, YYYY")}`}</p>
							<p>{`${offer.cityName} - ${offer.countryName}`}</p>
							{starOptions[offer.stars].label}
							<p>{`${offer.price}PLN za ${offer.numberOfPeople} ${offer.numberOfPeople > 1 ? "osób" : "osobę"}`}</p>
						</div>
					))}
				</div>
			</Spin>

			<AddOfferModal modalVisible={addOfferModalVisible} closeModal={() => setAddOfferModalVisible(false)} />
			<OfferModal offer={selectedOffer} closeModal={() => setSelectedOffer(undefined)} />
		</>
	);
};

export default HomePage;
