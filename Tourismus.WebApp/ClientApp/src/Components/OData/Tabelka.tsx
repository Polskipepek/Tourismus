import { Table } from "antd";
import { ColumnsType } from "antd/lib/table";
interface ITabelkaProps {
	data: any;
	columns: ColumnsType<any>;
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
			<Table dataSource={props.data} columns={props.columns} rowKey="Id"></Table>
		</>
	);
};

export default Tabelka;
