import { Col, Row } from "antd";
import { Form, FormikBag, FormikProps, withFormik } from "formik";
import React from "react";

import { SendActionWithResponseAndNotification } from "../../../_Infrastructure/Actions/SendAction";
import TextInputF from "../../../_Infrastructure/Formik/Components/TextInputF";
import { IModalComponentProps } from "../../../_Infrastructure/Modals/IModalComponentProps";
import Yup from "../../../_Infrastructure/Validation/YupValidation";
import Resources from "../../../Resources";
import { AuthenticateWithCredentialsParameters, AuthenticateWithCredentialsClient } from "../../../services/GeneratedClient";

interface ILoginFormProps extends IModalComponentProps {}
interface ILoginFormValues {
	email: string | undefined;
	password: string | undefined; // to idzie z DTO
}

class InnerForm extends React.Component<ILoginFormProps & FormikProps<ILoginFormValues>> {
	public render() {
		return (
			<Form id="login-form" name="LoginForm" className="formStyle">
				<Row gutter={[8, 16]}>
					<Col span={24}>
						<TextInputF {...this.props} name="email" placeholder={Resources.InputPlaceholder.email} />
					</Col>
					<Col span={24}>
						<TextInputF {...this.props} name="password" placeholder={Resources.InputPlaceholder.password} isPassword />
					</Col>
				</Row>
			</Form>
		);
	}
}

const validationSchema: Yup.SchemaOf<ILoginFormValues> = Yup.object({
	email: Yup.string().email().defined(),
	password: Yup.string().min(4).max(30).defined(),
});

const LoginFormInner = withFormik<ILoginFormProps, ILoginFormValues>({
	validateOnChange: false,
	validateOnBlur: false,
	validationSchema: validationSchema,
	mapPropsToValues: (props: ILoginFormProps) => {
		const mappedProps: ILoginFormValues = {
			email: undefined,
			password: undefined,
		};
		return mappedProps;
	},
	handleSubmit: (values: ILoginFormValues, bag: FormikBag<ILoginFormProps, ILoginFormValues>) => {
		var params = new AuthenticateWithCredentialsParameters({
			password: values.password,
			mail: values.email,
		});
		SendActionWithResponseAndNotification({
			action: () => new AuthenticateWithCredentialsClient().authenticate(params),
			onSuccess: (resp) => {
				bag.resetForm();
				bag.props.closeModal();
			},
			successTitle: Resources.Notifications.loginForm_successTitle,
			successMessage: Resources.Notifications.loginForm_successMessage,
			failureTitle: Resources.Notifications.loginForm_failureTitle,
			failureMessage: Resources.Notifications.loginForm_failureMessage,
		});
	},
})(InnerForm);

export const LoginForm = LoginFormInner;
