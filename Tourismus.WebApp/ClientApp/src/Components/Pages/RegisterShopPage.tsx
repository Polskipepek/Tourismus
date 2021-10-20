import { Col, Row } from "antd";
import React from "react";
import { FunctionComponent } from "react";
import { RouteComponentProps } from "react-router-dom";
import Resources from "../../Resources";
import { RegistrationShopForm } from "../Shop/RegistrationShopForm";

interface IMatchParams {
    token: string;
}

interface IRegisterShopProps extends RouteComponentProps<IMatchParams> {}

export const RegisterShopPage: FunctionComponent<IRegisterShopProps> = (props) => {
    const token = props.match.params.token;

    if (token == "test") {
        return (
            <>
                <Row>
                    <Col span={12} offset={6}>
                        <h2>{Resources.RegistrationShopPage.textOnValidToken}</h2>
                        <RegistrationShopForm />
                    </Col>
                </Row>
            </>
        );
    } else {
        return (
            <Row>
                <Col span={12} offset={6}>
                    {Resources.RegistrationShopPage.textOnUnvalidToken}
                </Col>
            </Row>
        );
    }
};
