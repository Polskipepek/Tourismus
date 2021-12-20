import { Spin } from "antd";
import { FunctionComponent, useContext, useEffect, useState } from "react";
import { AppContext, IAppContext } from "../../App";
import { openErrorNotification, openNotification } from "../../Helpers/NotificationHelper";
import Resources from "../../Resources";

import { BookOfferParameters, OfferClient, OfferList_Dto } from "../../services/GeneratedClient";
import { starOptions } from "../Hotel/AddHotelForm";

import { AddOfferModal } from "../Offer/AddOfferModal";
import OfferModal from "../Offer/OfferModal";

interface IHomePageProps {}

export const HomePage: FunctionComponent<IHomePageProps> = (props) => {
	const [offers, setOffers] = useState<OfferList_Dto[]>([]);
	const [addOfferModalVisible, setAddOfferModalVisible] = useState<boolean>(false);
	const [selectedOffer, setSelectedOffer] = useState<OfferList_Dto | undefined>(undefined);

	const { user } = useContext<IAppContext>(AppContext);

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

	const bookOffer = () => {
		var params = new BookOfferParameters({
			offerId: selectedOffer?.id ?? -1,
			userId: user?.id ?? -1,
		});
		new OfferClient()
			.bookOffer(params)
			.then((resp) => openNotification(Resources.Notifications.successTitle, Resources.Notifications.successMessage))
			.catch((err) => openErrorNotification(Resources.Notifications.failureTitle, Resources.Notifications.failureMessage));
		setAddOfferModalVisible(false);
	};

	const offersFilter = {};

	return (
		<>
			<Spin spinning={offers.length == 0}>
				<div className="item-container">
					{offers.map((offer) => (
						<a className="card" onClick={() => setSelectedOffer(offer)} key={offer.id}>
							<h3>{`${offer.name}`}</h3>
							<p>{`Od ${offer.dateFrom.format("MMM DD, YYYY")} do  ${offer.dateTo.format("MMM DD, YYYY")}`}</p>
							<p>{`${offer.cityName} - ${offer.countryName}`}</p>
							{starOptions[offer.stars].label}
							<p>{`${offer.price}PLN za ${offer.numberOfPeople} ${offer.numberOfPeople > 1 ? "osób" : "osobę"}`}</p>
						</a>
					))}
				</div>
			</Spin>

			<AddOfferModal modalVisible={addOfferModalVisible} closeModal={() => setAddOfferModalVisible(false)} />
			<OfferModal offer={selectedOffer} closeModal={() => setSelectedOffer(undefined)} onBookClicked={() => bookOffer()} />
		</>
	);
};

export default HomePage;
