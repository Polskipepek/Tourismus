import "./city.css";

import { Button, Modal } from "antd";

import { CheckCircleTwoTone } from "@ant-design/icons";

import { IModalComponentProps } from "../../_Infrastructure/Modals/IModalComponentProps";
import Resources from "../../Resources";
import { AddCityForm } from "./AddCityForm";
import { Country_Dto } from "../../services/GeneratedClient";

interface IAddCityModalProps extends IModalComponentProps {
	modalVisible: boolean;
	countriesToAddCity: Country_Dto[];
}

export const AddCityModal: React.FunctionComponent<IAddCityModalProps> = (props) => {
	return (
		<>
			<Modal
				className="addCity-modal"
				title={Resources.PageHeader.CityModalHeader}
				centered
				visible={props.modalVisible}
				onCancel={() => props.closeModal()}
				destroyOnClose
				footer={[
					<Button form="addCity-form" key="submit" htmlType="submit" type="primary">
						<CheckCircleTwoTone />
					</Button>,
				]}>
				<AddCityForm countries={props.countriesToAddCity} {...props} />
			</Modal>
		</>
	);
};
