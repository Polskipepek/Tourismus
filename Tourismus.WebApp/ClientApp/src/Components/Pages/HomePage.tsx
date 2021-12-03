import { FunctionComponent } from "react";

import Resources from "../../Resources";
import { IOffer_ListDto } from "../../services/ListDtos/Offer_ListDto";
import { ODataList } from "../../_Infrastructure/OData/Lists/ODataList";
import { ODataListType } from "../../_Infrastructure/OData/Lists/ODataListType";
import Karuzela from "../OData/Karuzela";

interface IHomePageProps {}

export const HomePage: FunctionComponent<IHomePageProps> = (props) => {
	return (
		<>
			<h1>{Resources.PageHeader.homePage}</h1>
			{/* <ODataList {...props} oDataListType={ODataListType.Offers} filter={[]} render={(data: IOffer_ListDto[]) => <Karuzela data={data} />} /> */}
		</>
	);
};

export default HomePage;
