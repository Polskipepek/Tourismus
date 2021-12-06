import "./city.css";

import { Button, Modal } from "antd";

import { CheckCircleTwoTone } from "@ant-design/icons";

import { IModalComponentProps } from "../../_Infrastructure/Modals/IModalComponentProps";
import Resources from "../../Resources";
import { AddMealForm } from "./AddMealForm";

interface IAddMealModalProps extends IModalComponentProps {
	modalVisible: boolean;
}

export const AddMealModal: React.FunctionComponent<IAddMealModalProps> = (props) => {
	return (
		<>
			<Modal
				className="addMeal-modal"
				title={Resources.ModalHeader.AddMeal}
				centered
				visible={props.modalVisible}
				onCancel={() => props.closeModal()}
				destroyOnClose
				footer={[
					<Button form="addMeal-form" key="submit" htmlType="submit" type="primary">
						<CheckCircleTwoTone />
					</Button>,
				]}>
				<AddMealForm {...props} />
			</Modal>
		</>
	);
};
