import { Col, Row } from "antd";
import { Form, FormikBag, FormikProps, withFormik } from "formik";
import React from "react";
import { openErrorNotification } from "../../Helpers/NotificationHelper";
import Resources from "../../Resources";
import { EditUserParameters, IUser, IUser_Dto, UserClient } from "../../services/GeneratedClient";
import { SendActionWithResponseAndNotification } from "../../_Infrastructure/Actions/SendAction";
import TextInputF from "../../_Infrastructure/Formik/Components/TextInputF";
import { IModalComponentProps } from "../../_Infrastructure/Modals/IModalComponentProps";
import Yup from "../../_Infrastructure/Validation/YupValidation";

interface IEditUserFormProps extends IModalComponentProps {
	closeModal: () => void;
	user: IUser_Dto;
}

interface IEditUserFormValues {
	// TO IDZIE Z DTO
	firstName: string | undefined;
	lastName: string | undefined;
	telephoneNumber: string | undefined;
	email: string | undefined;
	password: string | undefined;
}

class InnerForm extends React.Component<IEditUserFormProps & FormikProps<IEditUserFormValues>> {
	public render() {
		return (
			<Form id="EditUser-form" name="EditUserForm" className="formStyle">
				<Row gutter={[8, 16]}>
					<Col span={24}>
						<TextInputF {...this.props} name="firstName" placeholder={Resources.InputPlaceholder.firstName} />
					</Col>
				</Row>{" "}
				<Row gutter={[8, 16]}>
					<Col span={24}>
						<TextInputF {...this.props} name="lastName" placeholder={Resources.InputPlaceholder.lastName} />
					</Col>
				</Row>{" "}
				<Row gutter={[8, 16]}>
					<Col span={24}>
						<TextInputF {...this.props} name="email" placeholder={Resources.InputPlaceholder.email} />
					</Col>
				</Row>{" "}
				<Row gutter={[8, 16]}>
					<Col span={24}>
						<TextInputF {...this.props} name="telephoneNumber" placeholder={Resources.InputPlaceholder.telephoneNumber} isNumeric />
					</Col>
				</Row>{" "}
				<Row gutter={[8, 16]}>
					<Col span={24}>
						<TextInputF {...this.props} name="password" placeholder={Resources.InputPlaceholder.password} isPassword />
					</Col>
				</Row>
			</Form>
		);
	}
}

const passwordRegExp = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/;
const phoneRegExp = /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/;

const validationSchema: Yup.SchemaOf<IEditUserFormValues> = Yup.object({
	firstName: Yup.string().defined().min(2),
	lastName: Yup.string().defined().min(2),
	telephoneNumber: Yup.string().defined().min(2).matches(phoneRegExp, Resources.Validation.phoneNumber),
	email: Yup.string().defined().min(2),
	password: Yup.string().min(6).matches(passwordRegExp, Resources.Validation.passwordPolicy),
});

const EditUserFormInner = withFormik<IEditUserFormProps, IEditUserFormValues>({
	validateOnChange: false,
	validateOnBlur: false,
	validationSchema: validationSchema,
	mapPropsToValues: (props: IEditUserFormProps) => {
		const mappedProps: IEditUserFormValues = {
			firstName: props.user.firstName,
			lastName: props.user.lastName,
			email: props.user.email,
			telephoneNumber: props.user.telephoneNumber,
			password: "",
		};
		return mappedProps;
	},
	handleSubmit: (values: IEditUserFormValues, bag: FormikBag<IEditUserFormProps, IEditUserFormValues>) => {
		var params = new EditUserParameters({
			firstName: values.firstName,
			lastName: values.lastName,
			email: values.email,
			telephoneNumber: values.telephoneNumber,
			password: values.password,
			id: bag.props.user.id,
		});
		SendActionWithResponseAndNotification({
			action: () => new UserClient().updateUser(params),
			onSuccess: () => {
				bag.resetForm();
				bag.props.closeModal();
			},
			onFailure: () => {
				openErrorNotification(`Ups!`, "An unexpected server error occurred.");
			},
			successTitle: Resources.Notifications.successTitle,
			successMessage: Resources.Notifications.successMessage,
			failureTitle: Resources.Notifications.failureTitle,
			failureMessage: Resources.Notifications.failureMessage,
		});
	},
})(InnerForm);

export const EditUserForm = EditUserFormInner;
