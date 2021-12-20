import { Spin, Image } from "antd";
import moment from "moment";
import { useEffect, useState } from "react";
import { IOfferList_Dto } from "../../services/GeneratedClient";
import { IOffer_DetailsDto } from "../../services/SingleDto/Offer_DetailsDto";
import { ODataSingle } from "../../_Infrastructure/OData/Singles/ODataSingle";
import { ODataSingleType } from "../../_Infrastructure/OData/Singles/ODataSingleType";
import { starOptions } from "../Hotel/AddHotelForm";

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
						<div>
							Nazwa oferty: <h3>{`${offerDetails?.name ?? "NoName"}`}</h3>
						</div>
						<div>
							Data: <h3>{`Od ${moment(offerDetails!.dateFrom).format("MMM DD, YYYY")} do  ${moment(offerDetails!.dateTo).format("MMM DD, YYYY")}`}</h3>
						</div>
						<div>
							Lokalizacja:<h3>{`${offerDetails!.cityName} - ${offerDetails!.countryName}`}</h3>
						</div>
						{starOptions[offerDetails!.stars].label}
						<div>
							Cena: <h3>{`${offerDetails!.price}PLN za ${offerDetails!.numberOfPeople} ${offerDetails!.numberOfPeople > 1 ? "osób" : "osobę"}`}</h3>
						</div>
						<div>
							Posiłki:<h3>{`${offerDetails?.mealType}`}</h3>
						</div>
						<div>
							Szczegóły:<h3>{`${offerDetails?.description}`}</h3>
						</div>
					</>
				)}
			</Spin>
		</>
	);
};

export default OfferContentWrapper;
