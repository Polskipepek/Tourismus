import { Spin, Image } from "antd";
import moment from "moment";
import { useEffect, useState } from "react";
import { IOfferList_Dto } from "../../services/GeneratedClient";
import { IOffer_DetailsDto } from "../../services/SingleDto/Offer_DetailsDto";
import { ODataSingle } from "../../_Infrastructure/OData/Singles/ODataSingle";
import { ODataSingleType } from "../../_Infrastructure/OData/Singles/ODataSingleType";
import { starOptions } from "../Hotel/AddHotelForm";
//import img1 from "../../Images/atoll-gc9d027e3d_1920.jpg";

interface IOfferContentProps {
	offer: IOfferList_Dto | undefined;
}

const OfferContentWrapper: React.FC<IOfferContentProps> = (props) => {
	const [offerDetails, setOfferDetails] = useState<IOffer_DetailsDto | undefined>();

	useEffect(() => {}, [offerDetails]);

	var filter = {
		Id: props.offer?.id,
	};

	return (
		<>
			<ODataSingle oDataSingleType={ODataSingleType.OfferDetails} filter={filter} render={(offer: IOffer_DetailsDto) => setOfferDetails(offer)} />
			<Spin spinning={offerDetails == undefined}>
				{offerDetails != undefined && (
					<>
						{console.log(offerDetails)}
						<h3>{`${offerDetails?.name ?? "NoName"}`}</h3>
						<h3>{`Od ${moment(offerDetails!.dateFrom).format("MMM DD, YYYY")} do  ${moment(offerDetails!.dateTo).format("MMM DD, YYYY")}`}</h3>
						<h3>{`${offerDetails!.cityName} - ${offerDetails!.countryName}`}</h3>
						{starOptions[offerDetails!.stars].label}
						<h3>{`${offerDetails!.price}PLN za ${offerDetails!.numberOfPeople} ${offerDetails!.numberOfPeople > 1 ? "osób" : "osobę"}`}</h3>
						<p>
							Posiłki:<h3>{`${offerDetails?.mealType}`}</h3>
						</p>
						<h3>{`Opis: ${offerDetails?.description}`}</h3>
						{/* 	<Image width={300} src={img1} /> */}
					</>
				)}
			</Spin>
		</>
	);
};

export default OfferContentWrapper;
