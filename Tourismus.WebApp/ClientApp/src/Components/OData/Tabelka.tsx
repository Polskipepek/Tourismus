import { Table } from "antd";
import { ColumnsType } from "antd/lib/table";
interface ITabelkaProps {
	data: any;
	title?: string;
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
			<Table dataSource={props.data} columns={props.columns} rowKey="Id" title={() => (props.title ? props.title : "")}></Table>
		</>
	);
};

export default Tabelka;
