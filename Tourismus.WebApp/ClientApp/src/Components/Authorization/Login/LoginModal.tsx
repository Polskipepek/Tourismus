import "./login.css";

import { Button, Modal, Tooltip } from "antd";

import { CheckCircleTwoTone } from "@ant-design/icons";

import { IModalComponentProps } from "../../../_Infrastructure/Modals/IModalComponentProps";
import Resources from "../../../Resources";
import { LoginForm } from "./LoginForm";
import { useContext, useEffect } from "react";
import { AppContext, IAppContext } from "../../../App";
import { IUser } from "../../../services/GeneratedClient";

interface ILoginProps extends IModalComponentProps {
	modalVisible: boolean;
}

export const LoginModal: React.FunctionComponent<ILoginProps> = (props) => {
	const { toggleUser } = useContext<IAppContext>(AppContext);

	const setUser = (user: IUser | undefined) => {
		if (toggleUser) {
			toggleUser(user);
		}
	};

	return (
		<>
			<Modal
				className="login-modal"
				title={Resources.PageHeader.loginPage}
				centered
				visible={props.modalVisible}
				onCancel={() => props.closeModal()}
				destroyOnClose
				footer={[
					<Tooltip title="Zaloguj">
						<Button form="login-form" key="submit" htmlType="submit" type="primary">
							<CheckCircleTwoTone />
						</Button>
					</Tooltip>,
				]}>
				<LoginForm {...props} toggleUser={setUser} />
			</Modal>
		</>
	);
};
