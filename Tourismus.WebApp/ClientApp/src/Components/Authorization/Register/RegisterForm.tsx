import { Col, Row } from "antd";
import Password from "antd/lib/input/Password";
import { Form, FormikBag, FormikProps, withFormik } from "formik";
import React from "react";

import { PropertySafetyTwoTone } from "@ant-design/icons";

import { SendActionWithResponseAndNotification } from "../../../_Infrastructure/Actions/SendAction";
import TextInputF from "../../../_Infrastructure/Formik/Components/TextInputF";
import { IModalComponentProps } from "../../../_Infrastructure/Modals/IModalComponentProps";
import Yup from "../../../_Infrastructure/Validation/YupValidation";
import Resources from "../../../Resources";
import { AuthenticateWithCredentialsParameters, AuthenticateWithCredentialsClient, UserClient, AddNewUserParameters } from "../../../services/GeneratedClient";

interface IRegisterFormProps extends IModalComponentProps {}
interface IRegisterFormValues {
	email: string | undefined;
	password: string | undefined;
	passwordConfirmation: string | undefined;
	phoneNumber: string | undefined;
	firstName: string | undefined;
	lastName: string | undefined;
}

class InnerForm extends React.Component<IRegisterFormProps & FormikProps<IRegisterFormValues>> {
	public render() {
		return (
			<Form id="register-form" name="RegisterForm" className="formStyle">
				<Row gutter={[8, 16]}>
					<Col span={24}>
						<TextInputF {...this.props} name="firstName" placeholder={Resources.InputPlaceholder.firstName} />
					</Col>{" "}
					<Col span={24}>
						<TextInputF {...this.props} name="lastName" placeholder={Resources.InputPlaceholder.lastName} />
					</Col>
					<Col span={24}>
						<TextInputF {...this.props} name="email" placeholder={Resources.InputPlaceholder.email} />
					</Col>
					<Col span={24}>
						<TextInputF {...this.props} name="password" placeholder={Resources.InputPlaceholder.password} isPassword />
					</Col>
					<Col span={24}>
						<TextInputF {...this.props} name="passwordConfirmation" placeholder={Resources.InputPlaceholder.password} isPassword />
					</Col>
					<Col span={24}>
						<TextInputF {...this.props} name="phoneNumber" placeholder={Resources.InputPlaceholder.phoneNumber} />
					</Col>
				</Row>
			</Form>
		);
	}
}

const passwordRegExp = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/;
const phoneRegExp = /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/;

const validationSchema: Yup.SchemaOf<IRegisterFormValues> = Yup.object({
	email: Yup.string().email().defined(),
	password: Yup.string().min(8).max(30).matches(passwordRegExp, Resources.Validation.passwordPolicy).defined(),
	passwordConfirmation: Yup.string()
		.min(8)
		.max(30)
		.defined()
		.oneOf([Yup.ref("password"), null], Resources.Validation.passwordConfirmation),
	firstName: Yup.string().min(2).max(30).defined(),
	lastName: Yup.string().min(4).max(30).defined(),
	phoneNumber: Yup.string().min(4).max(30).defined().matches(phoneRegExp, Resources.Validation.phoneNumber),
});

const RegisterFormInner = withFormik<IRegisterFormProps, IRegisterFormValues>({
	validateOnChange: false,
	validateOnBlur: false,
	validationSchema: validationSchema,
	mapPropsToValues: (props: IRegisterFormProps) => {
		const mappedProps: IRegisterFormValues = {
			firstName: undefined,
			email: undefined,
			password: undefined,
			passwordConfirmation: undefined,
			phoneNumber: undefined,
			lastName: undefined,
		};
		return mappedProps;
	},
	handleSubmit: (values: IRegisterFormValues, bag: FormikBag<IRegisterFormProps, IRegisterFormValues>) => {
		var params = new AddNewUserParameters({
			password: values.password,
			email: values.email,
			firstName: values.firstName,
			lastName: values.lastName,
			telephoneNumber: values.phoneNumber,
		});
		SendActionWithResponseAndNotification({
			action: () => new UserClient().addNewUserAction(params),
			onSuccess: (resp) => {
				bag.resetForm();
				bag.props.closeModal();
			},
			successTitle: Resources.Notifications.registerForm_successTitle,
			successMessage: Resources.Notifications.registerForm_successMessage,
			failureTitle: Resources.Notifications.registerForm_failureTitle,
			failureMessage: Resources.Notifications.registerForm_failureMessage,
		});
	},
})(InnerForm);

export const RegisterForm = RegisterFormInner;
