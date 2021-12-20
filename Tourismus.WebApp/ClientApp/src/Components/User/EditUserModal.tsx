import "./user.css";

import { Button, Modal } from "antd";

import { CheckCircleTwoTone } from "@ant-design/icons";

import { IModalComponentProps } from "../../_Infrastructure/Modals/IModalComponentProps";
import Resources from "../../Resources";
import { EditUserForm } from "./EditUserForm";
import { IUser_Dto } from "../../services/GeneratedClient";

interface IEditUserModalProps extends IModalComponentProps {
	modalVisible: boolean;
	userDto: IUser_Dto;
}

export const EditUserModal: React.FunctionComponent<IEditUserModalProps> = (props) => {
	return (
		<>
			<Modal
				className="editUser-modal"
				title={Resources.ModalHeader.EditUser}
				centered
				visible={props.modalVisible}
				onCancel={() => props.closeModal()}
				destroyOnClose
				footer={[
					<Button form="EditUser-form" key="submit" htmlType="submit" type="primary">
						<CheckCircleTwoTone />
					</Button>,
				]}>
				{props.userDto != undefined && <EditUserForm user={props.userDto} {...props} />}
			</Modal>
		</>
	);
};
