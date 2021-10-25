import { FunctionComponent } from "react";

import Resources from "../../Resources";

interface IHomePageProps {}

export const HomePage: FunctionComponent<IHomePageProps> = (props) => {
	return (
		<>
			<h1>{Resources.PageHeader.homePage}</h1>

			{/*<ODataList {...props} oDataListType={ODataListType.Products} filter={filter} render={(data: IProduct_ListDto[]) => <Tabelka {...props} data={data} />} />*/}
		</>
	);
};

export default HomePage;
