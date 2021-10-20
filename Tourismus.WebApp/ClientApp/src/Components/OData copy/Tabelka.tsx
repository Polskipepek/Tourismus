import { Table } from "antd";
import { IProduct_ListDto } from "../../services/ListDtos/Product_ListDto";
interface ITabelkaProps {
	data: IProduct_ListDto[];
}

const Tabelka: React.FunctionComponent<ITabelkaProps> = (props) => {
	const columns = [
		{
			key: "Name",
			title: "Name",
			dataIndex: "Name",
		},
		{
			key: "Price",
			title: "Price",
			dataIndex: "Price",
		},
	];

	return (
		<>
			<Table dataSource={props.data} columns={columns} rowKey="Id"></Table>
		</>
	);
};

export default Tabelka;
