import { Layout, Menu } from "antd";
import React, { useContext, useState } from "react";
import { RouteComponentProps } from "react-router";
import { withRouter } from "react-router-dom";

import { CopyrightOutlined, HomeOutlined } from "@ant-design/icons";

import Resources from "../Resources";
import { LoginModal } from "./Authorization/Login/LoginModal";
import { RegisterModal } from "./Authorization/Register/RegisterModal";
import { IUser, UserClient } from "../services/GeneratedClient";
import { AppContext, IAppContext } from "../App";
import { openNotification } from "../Helpers/NotificationHelper";

const { Header, Footer, Content } = Layout;

const MainLayout: React.FunctionComponent<RouteComponentProps> = (props) => {
	const [loginModalVisibility, setLoginModalVisibility] = useState<boolean>(false);
	const [registerModalVisibility, setRegisterModalVisibility] = useState<boolean>(false);
	const [selectedKey, setSelectedKey] = useState<string>("1");
	const { user, toggleUser } = useContext<IAppContext>(AppContext);

	const signOut = () => {
		new UserClient().signOut().then((resp) => {
			if (toggleUser) toggleUser(undefined);
			openNotification(Resources.Notifications.logOut_successTitle, Resources.Notifications.logOut_successMessage);
		});
	};

	const changePage = (page: string) => {
		props.history.push(page);
		setSelectedKey(page);
	};

	const getCurrentPage = () => {
		switch (props.history.location.pathname) {
			case Resources.AvailablePages.homePage:
				return "1";
			case Resources.AvailablePages.userProfilePage:
				return "2";
			case Resources.AvailablePages.aboutUsPage:
				return "3";
			case Resources.AvailablePages.adminDashboardPage:
				return "4";
		}
	};

	return (
		<>
			<Layout>
				<Header style={{ position: "fixed", zIndex: 1, width: "100%", backgroundColor: "#fff" }}>
					<Menu mode="horizontal" theme="light" style={{ textAlign: "center" }} selectedKeys={[selectedKey]}>
						<Menu.Item key="1" style={{ float: "left" }} onClick={() => changePage(Resources.AvailablePages.homePage)}>
							<HomeOutlined />
							{Resources.PageNames.homePage}
						</Menu.Item>
						{user && (
							<Menu.Item key="2" style={{ float: "left" }} onClick={() => changePage(Resources.AvailablePages.userProfilePage)}>
								{Resources.PageNames.profilePage}
							</Menu.Item>
						)}
						{user != undefined && (
							<Menu.Item key="3" style={{ float: "left" }} onClick={() => changePage(Resources.AvailablePages.aboutUsPage)}>
								{Resources.PageNames.aboutUsPage}
							</Menu.Item>
						)}
						{user?.isAdmin && (
							<Menu.Item key="4" style={{ float: "left" }} onClick={() => changePage(Resources.AvailablePages.adminDashboardPage)}>
								{Resources.PageNames.adminDashboardPage}
							</Menu.Item>
						)}
						{user == undefined && (
							<Menu.Item key="98" style={{ float: "right" }} onClick={() => setLoginModalVisibility(true)}>
								{Resources.Buttons.layout_signIn}
							</Menu.Item>
						)}
						{user == undefined && (
							<Menu.Item key="97" style={{ float: "right" }} onClick={() => setRegisterModalVisibility(true)}>
								{Resources.Buttons.layout_register}
							</Menu.Item>
						)}
						{user != undefined && (
							<Menu.Item key="99" style={{ float: "right" }} onClick={() => signOut()}>
								{Resources.Buttons.layout_signOut}
							</Menu.Item>
						)}
					</Menu>
				</Header>
				<Content
					className=".site-layout-conten"
					style={{
						padding: "0 50px",
						marginTop: 80,
						marginLeft: 80,
						marginRight: 80,
						bottom: 100,
					}}>
					{props.children}
				</Content>
				<Footer className=".footer">
					<div
						style={{
							marginLeft: 80,
							marginRight: 80,
							textAlign: "center",
							bottom: 0,
						}}>
						Copyright <CopyrightOutlined />
					</div>
				</Footer>
			</Layout>

			<LoginModal closeModal={() => setLoginModalVisibility(false)} modalVisible={loginModalVisibility} />
			<RegisterModal closeModal={() => setRegisterModalVisibility(false)} modalVisible={registerModalVisibility} />
		</>
	);
};

export default withRouter(MainLayout);
