import { Col, Row } from "antd";
import { Form, FormikBag, FormikProps, withFormik } from "formik";
import React, { useContext } from "react";
import Resources from "../../Resources";
import { AddNewCountryParameters, CountryClient } from "../../services/GeneratedClient";
import { SendActionWithResponseAndNotification } from "../../_Infrastructure/Actions/SendAction";
import TextInputF from "../../_Infrastructure/Formik/Components/TextInputF";
import { IModalComponentProps } from "../../_Infrastructure/Modals/IModalComponentProps";
import Yup from "../../_Infrastructure/Validation/YupValidation";

interface IAddCountryFormProps extends IModalComponentProps {
	closeModal: () => void;
}

interface IAddCountryFormValues {
	name: string | undefined; // to idzie z DTO
}

class InnerForm extends React.Component<IAddCountryFormProps & FormikProps<IAddCountryFormValues>> {
	public render() {
		return (
			<Form id="addCountry-form" name="addCountryForm" className="formStyle">
				<Row gutter={[8, 16]}>
					<Col span={24}>
						<TextInputF {...this.props} name="name" placeholder={Resources.InputPlaceholder.countryName} />
					</Col>
				</Row>
			</Form>
		);
	}
}

const validationSchema: Yup.SchemaOf<IAddCountryFormValues> = Yup.object({
	name: Yup.string().defined().min(3),
});

const AddCountryFormInner = withFormik<IAddCountryFormProps, IAddCountryFormValues>({
	validateOnChange: false,
	validateOnBlur: false,
	validationSchema: validationSchema,
	mapPropsToValues: (props: IAddCountryFormProps) => {
		const mappedProps: IAddCountryFormValues = {
			name: undefined,
		};
		return mappedProps;
	},
	handleSubmit: (values: IAddCountryFormValues, bag: FormikBag<IAddCountryFormProps, IAddCountryFormValues>) => {
		var params = new AddNewCountryParameters({
			name: values.name,
		});
		SendActionWithResponseAndNotification({
			action: () => new CountryClient().addNewCountryAction(params),
			onSuccess: () => {
				bag.resetForm();
				bag.props.closeModal();
			},
			successTitle: Resources.Notifications.successTitle,
			successMessage: Resources.Notifications.successMessage,
			failureTitle: Resources.Notifications.failureTitle,
			failureMessage: Resources.Notifications.failureMessage,
		});
	},
})(InnerForm);

export const AddCountryForm = AddCountryFormInner;
