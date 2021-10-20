import { Button, Layout, Menu } from 'antd';
import React, { useState } from 'react';
import { RouteComponentProps } from 'react-router';
import { withRouter } from 'react-router-dom';

import { CopyrightOutlined, HomeOutlined } from '@ant-design/icons';

import Resources from '../Resources';
import { LoginModal } from './Authorization/Login/LoginModal';
import { RegisterModal } from './Authorization/Register/RegisterModal';

const { Header, Footer, Content } = Layout;

const ShoppingLayout: React.FunctionComponent<RouteComponentProps> = (props) => {
  const [loginModalVisibility, setLoginModalVisibility] = useState<boolean>(false);
  const [registerModalVisibility, setRegisterModalVisibility] = useState<boolean>(false);
  const [selectedKey, setSelectedKey] = useState<string>("1");

  const changePage = (page: string, menuItemId: string) => {
    props.history.push(page);
    if (menuItemId != "4") setSelectedKey(menuItemId);
  };

  const getCurrentPage = () => {
    switch (props.history.location.pathname) {
      case Resources.AvailablePages.homePage:
        return "1";
      case Resources.AvailablePages.userProfilePage:
        return "2";
      case Resources.AvailablePages.aboutUsPage:
        return "3";
    }
  };

  return (
    <>
      <Layout>
        <Header style={{ position: "fixed", zIndex: 1, width: "100%" }}>
          <Menu mode="horizontal" theme="dark" style={{ textAlign: "center" }} selectedKeys={[selectedKey]}>
            <Menu.Item key="1" style={{ float: "left" }} onClick={() => changePage(Resources.AvailablePages.homePage, "1")}>
              <HomeOutlined />
              {Resources.PageNames.homePage}
            </Menu.Item>
            <Menu.Item key="2" style={{ float: "left" }} onClick={() => changePage(Resources.AvailablePages.userProfilePage, "2")}>
              {Resources.PageNames.profilePage}
            </Menu.Item>
            <Menu.Item key="3" style={{ float: "left" }} onClick={() => changePage(Resources.AvailablePages.aboutUsPage, "3")}>
              {Resources.PageNames.aboutUsPage}
            </Menu.Item>
            <Menu.Item key="4" style={{ float: "right" }} onClick={() => setLoginModalVisibility(true)}>
              {Resources.Buttons.layout_signIn}
            </Menu.Item>
            <Menu.Item key="5" style={{ float: "right" }} onClick={() => setRegisterModalVisibility(true)}>
              {Resources.Buttons.layout_register}
            </Menu.Item>
          </Menu>
        </Header>
        <Content
          className=".site-layout-conten"
          style={{
            padding: "0 50px",
            marginTop: 80,
            marginLeft: 80,
            marginRight: 80,
          }}
        >
          {props.children}
        </Content>
        <Footer className=".footer">
          <div
            style={{
              marginLeft: 80,
              marginRight: 80,
              textAlign: "center",
            }}
          >
            Copyright <CopyrightOutlined />
          </div>
        </Footer>
      </Layout>

      <LoginModal closeModal={() => setLoginModalVisibility(false)} modalVisible={loginModalVisibility} />
      <RegisterModal closeModal={() => setRegisterModalVisibility(false)} modalVisible={registerModalVisibility} />
    </>
  );
};

export default withRouter(ShoppingLayout);
