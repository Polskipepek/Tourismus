import { Col, Row } from "antd";
import { Form, FormikBag, FormikProps, withFormik } from "formik";
import React from "react";
import { nameof } from "ts-simple-nameof";
import Resources from "../../Resources";
import { AddNewMealParameters, MealClient, IMeal_Dto, IAddNewMealParameters as IFormValues } from "../../services/GeneratedClient";
import { SendActionWithResponseAndNotification } from "../../_Infrastructure/Actions/SendAction";
import TextInputF from "../../_Infrastructure/Formik/Components/TextInputF";
import { IModalComponentProps } from "../../_Infrastructure/Modals/IModalComponentProps";
import Yup from "../../_Infrastructure/Validation/YupValidation";

interface IAddMealFormProps extends IModalComponentProps {
	closeModal: () => void;
}

class InnerForm extends React.Component<IAddMealFormProps & FormikProps<IFormValues>> {
	public render() {
		return (
			<Form id="addMeal-form" name="addMealForm" className="formStyle">
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.meal}</Col>
					<Col span={20}>
						<TextInputF {...this.props} name={nameof<IFormValues>((x) => x.name)} placeholder={Resources.InputPlaceholder.meal} />
					</Col>
				</Row>
			</Form>
		);
	}
}

const validationSchema: Yup.SchemaOf<IFormValues> = Yup.object({
	name: Yup.string().defined().min(3),
});

const AddMealFormInner = withFormik<IAddMealFormProps, IFormValues>({
	validateOnChange: false,
	validateOnBlur: false,
	validationSchema: validationSchema,
	mapPropsToValues: (props: IAddMealFormProps) => {
		const mappedProps: IFormValues = {
			name: undefined,
		};
		return mappedProps;
	},
	handleSubmit: (values: IFormValues, bag: FormikBag<IAddMealFormProps, IFormValues>) => {
		var params = new AddNewMealParameters({
			name: values.name,
		});
		SendActionWithResponseAndNotification({
			action: () => new MealClient().addNewMealAction(params),
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

export const AddMealForm = AddMealFormInner;
