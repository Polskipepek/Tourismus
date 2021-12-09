import { Button, Carousel, Divider } from "antd";
import { off } from "process";
import { FunctionComponent, useEffect, useState } from "react";

import Resources from "../../Resources";
import { OfferClient, OfferList_Dto } from "../../services/GeneratedClient";
import { IOffer_ListDto } from "../../services/ListDtos/Offer_ListDto";
import { ODataList } from "../../_Infrastructure/OData/Lists/ODataList";
import { ODataListType } from "../../_Infrastructure/OData/Lists/ODataListType";
import Karuzela from "../OData/Karuzela";
import { AddOfferModal } from "../Offer/AddOfferModal";

interface IHomePageProps {}

export const HomePage: FunctionComponent<IHomePageProps> = (props) => {
	const [offers, setOffers] = useState<OfferList_Dto[]>([]);
	const [addOfferModalVisible, setAddOfferModalVisible] = useState<boolean>(false);

	useEffect(() => {
		getOffers();
	}, []);

	const getOffers = () => {
		/* 		new OfferClient().getListOffers().then((resp) => {
			if (resp != null && (resp as OfferList_Dto[])) {
				setOffers(resp);
			} 
		});*/
	};

	return (
		<>
			<h1>{Resources.PageHeader.homePage}</h1>
			<Button style={{ backgroundColor: "#aaa" }} key={"AddOfferBtn"} type="primary" title={Resources.Buttons.addOffer} onClick={() => setAddOfferModalVisible(true)}>
				{Resources.Buttons.addOffer}
			</Button>
			<Divider type="horizontal" />
			<Carousel>
				{offers &&
					offers.map((offer) => {
						<span>
							<h3>{offer.name}</h3>
							<h4>{offer.cityName + " - " + offer.countryName}</h4>
							<h4>{offer.numberOfPeople}</h4>
							<h4>{offer.price}</h4>
						</span>;
					})}
			</Carousel>

			<AddOfferModal modalVisible={addOfferModalVisible} closeModal={() => setAddOfferModalVisible(false)} />
		</>
	);
};

export default HomePage;
