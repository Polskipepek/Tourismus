import "./country.css";

import { Button, Modal } from "antd";

import { CheckCircleTwoTone } from "@ant-design/icons";

import { IModalComponentProps } from "../../_Infrastructure/Modals/IModalComponentProps";
import Resources from "../../Resources";
import { AddCountryForm } from "./AddCountryForm";

interface ILoginProps extends IModalComponentProps {
	modalVisible: boolean;
}

export const AddCountryModal: React.FunctionComponent<ILoginProps> = (props) => {
	return (
		<>
			<Modal
				className="addCountry-modal"
				title={Resources.PageHeader.CountryModalHeader}
				centered
				visible={props.modalVisible}
				onCancel={() => props.closeModal()}
				destroyOnClose
				footer={[
					<Button form="addCountry-form" key="submit" htmlType="submit" type="primary">
						<CheckCircleTwoTone />
					</Button>,
				]}>
				<AddCountryForm {...props} />
			</Modal>
		</>
	);
};
