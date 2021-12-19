import "./hotel.css";

import { Button, Modal } from "antd";

import { CheckCircleTwoTone } from "@ant-design/icons";

import { IModalComponentProps } from "../../_Infrastructure/Modals/IModalComponentProps";
import Resources from "../../Resources";
import { AddHotelForm } from "./AddHotelForm";

interface IAddHotelModalProps extends IModalComponentProps {
	modalVisible: boolean;
}

export const AddHotelModal: React.FunctionComponent<IAddHotelModalProps> = (props) => {
	return (
		<>
			<Modal
				className="addHotel-modal"
				title={Resources.ModalHeader.AddHotel}
				centered
				visible={props.modalVisible}
				onCancel={() => props.closeModal()}
				destroyOnClose
				footer={[
					<Button form="addHotel-form" key="submit" htmlType="submit" type="primary">
						<CheckCircleTwoTone />
					</Button>,
				]}>
				<AddHotelForm {...props} />
			</Modal>
		</>
	);
};
