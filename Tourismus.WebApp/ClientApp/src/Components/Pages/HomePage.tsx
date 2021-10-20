import { Row } from "antd";
import React, { FunctionComponent } from "react";
import { IShop_ListDto } from "../../services/ListDtos/Shop_ListDto";
import { IProduct_ListDto } from "../../services/ListDtos/Product_ListDto";
import { IProductDetails_Dto } from "../../services/SingleDto/ProductDetails_Dto";
import { ODataListType } from "../../_Infrastructure/OData/Lists/ODataListType";
import { ODataList } from "../../_Infrastructure/OData/Lists/ODataList";
import { ODataSingle } from "../../_Infrastructure/OData/Lists/ODataSingle";
import { ODataSingleType } from "../../_Infrastructure/OData/Lists/ODataSingleType";
import Resources from "../../Resources";
import ShopCards from "../OData/Shops/ShopCards";
import Tabelka from "../OData/Tabelka";

interface IHomePageProps {}

export const HomePage: FunctionComponent<IHomePageProps> = (props) => {
	const filter = {
		Price: { gt: 100 },
	};
	return (
		<>
			<ODataList
				{...props}
				oDataListType={ODataListType.Shops}
				filter={{}}
				render={(data: IShop_ListDto[]) => (
					<Row justify={"center"}>
						<ShopCards {...props} data={data} />
					</Row>
				)}
			/>
			<h1>{Resources.PageHeader.homePage}</h1>

			<ODataList {...props} oDataListType={ODataListType.Products} filter={filter} render={(data: IProduct_ListDto[]) => <Tabelka {...props} data={data} />} />

			<ODataSingle
				{...props}
				oDataSingleType={ODataSingleType.ProductDetails}
				filter={{ Id: 5 }}
				render={(data: IProductDetails_Dto) => (
					<>
						{data.price}
						{data.description}
					</>
				)}
			/>
		</>
	);
};

export default HomePage;
