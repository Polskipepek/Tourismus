import { Col, Row } from "antd";
import { Form, FormikBag, FormikProps, withFormik } from "formik";
import React from "react";
import { nameof } from "ts-simple-nameof";
import Resources from "../../Resources";
import { AddNewOfferParameters, OfferClient, City_Dto, Meal_Dto, Hotel_Dto } from "../../services/GeneratedClient";
import { SendActionWithResponseAndNotification } from "../../_Infrastructure/Actions/SendAction";
import TextInputF from "../../_Infrastructure/Formik/Components/TextInputF";
import { IModalComponentProps } from "../../_Infrastructure/Modals/IModalComponentProps";
import Yup from "../../_Infrastructure/Validation/YupValidation";
import moment from "moment";
import TextAreaF from "../../_Infrastructure/Formik/Components/TextAreaF";
import SelectF from "../../_Infrastructure/Formik/Components/SelectF";
import DateF from "../../_Infrastructure/Formik/Components/DateF";

interface IAddOfferFormProps extends IModalComponentProps {
	closeModal: () => void;
	cities: City_Dto[];
	hotels: Hotel_Dto[];
	meals: Meal_Dto[];
}
interface IFormValues {
	hotelId: number;
	cityId: number;
	dateFrom: Date | undefined;
	dateTo: Date | undefined;
	price: number;
	numberOfPeople: number;
	photoPaths: string | undefined;
	description: string | undefined;
	mealsId: number | undefined;
	name: string | undefined;
}

class InnerForm extends React.Component<IAddOfferFormProps & FormikProps<IFormValues>> {
	public render() {
		return (
			<Form id="addOffer-form" name="addOfferForm" className="formStyle">
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.name}</Col>
					<Col span={20}>
						<TextInputF {...this.props} name={nameof<IFormValues>((x) => x.name)} width={"100%"} placeholder={Resources.InputPlaceholder.name} />
					</Col>
				</Row>
				<br />
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.description}</Col>
					<Col span={20}>
						<TextAreaF {...this.props} rows={5} name={nameof<IFormValues>((x) => x.description)} width={"100%"} placeholder={Resources.InputPlaceholder.description} />
					</Col>
				</Row>
				<br />
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.cityName}</Col>
					<Col span={20}>
						<SelectF {...this.props} options={this.props.cities} width={"100%"} labelKey="name" valueKey="id" name={nameof<IFormValues>((x) => x.cityId)} placeholder={Resources.InputPlaceholder.cityName} />
					</Col>
				</Row>
				<br />
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.hotelId}</Col>
					<Col span={20}>
						<SelectF {...this.props} options={this.props.hotels} labelKey="name" width={"100%"} valueKey="id" name={nameof<IFormValues>((x) => x.cityId)} placeholder={Resources.InputPlaceholder.cityName} />
					</Col>
				</Row>
				<br />
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.dateFrom}</Col>
					<Col span={20}>
						<DateF {...this.props} name={nameof<IFormValues>((x) => x.dateFrom)} width={"100%"} picker="date" placeholder={Resources.InputPlaceholder.dateFrom} />
					</Col>
				</Row>
				<br />
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.dateTo}</Col>
					<Col span={20}>
						<DateF {...this.props} name={nameof<IFormValues>((x) => x.dateTo)} width={"100%"} picker="date" placeholder={Resources.InputPlaceholder.dateTo} />
					</Col>
				</Row>
				<br />
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.numberOfPeople}</Col>
					<Col span={20}>
						<TextInputF {...this.props} name={nameof<IFormValues>((x) => x.numberOfPeople)} width={"100%"} placeholder={Resources.InputPlaceholder.numberOfPeople} />
					</Col>
				</Row>
				<br />
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.price}</Col>
					<Col span={20}>
						<TextInputF {...this.props} name={nameof<IFormValues>((x) => x.price)} width={"100%"} placeholder={Resources.InputPlaceholder.price} />
					</Col>
				</Row>
				<br />
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.photoPaths}</Col>
					<Col span={20}>
						<TextInputF {...this.props} name={nameof<IFormValues>((x) => x.photoPaths)} width={"100%"} placeholder={Resources.InputPlaceholder.photoPaths} />
					</Col>
				</Row>
				<br />
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.mealsId}</Col>
					<Col span={20}>
						<SelectF {...this.props} options={this.props.meals} labelKey="name" valueKey="id" width={"100%"} name={nameof<IFormValues>((x) => x.cityId)} placeholder={Resources.InputPlaceholder.cityName} />
					</Col>
				</Row>
			</Form>
		);
	}
}

const validationSchema: Yup.SchemaOf<IFormValues> = Yup.object({
	name: Yup.string().defined().min(3),
	description: Yup.string().defined().min(3),
	hotelId: Yup.number().required(),
	cityId: Yup.number().defined(),
	mealsId: Yup.number().defined(),
	numberOfPeople: Yup.number().defined(),
	price: Yup.number().defined(),
	photoPaths: Yup.string(),
	dateFrom: Yup.date(),
	dateTo: Yup.date(),
});

const AddOfferFormInner = withFormik<IAddOfferFormProps, IFormValues>({
	validateOnChange: false,
	validateOnBlur: false,
	validationSchema: validationSchema,
	mapPropsToValues: (props: IAddOfferFormProps) => {
		const mappedProps: IFormValues = {
			name: undefined,
			description: undefined,
			dateFrom: new Date(),
			dateTo: new Date(),
			cityId: 0,
			hotelId: 0,
			mealsId: 0,
			numberOfPeople: 0,
			photoPaths: undefined,
			price: 0,
		};
		return mappedProps;
	},
	handleSubmit: (values: IFormValues, bag: FormikBag<IAddOfferFormProps, IFormValues>) => {
		var params = new AddNewOfferParameters({
			name: values.name,
			cityId: values.cityId,
			dateFrom: moment(values.dateFrom),
			dateTo: moment(values.dateFrom),
			description: values.description,
			hotelId: values.hotelId,
			mealsId: values.mealsId,
			numberOfPeople: values.numberOfPeople,
			photoPaths: values.photoPaths,
			price: values.price,
		});
		SendActionWithResponseAndNotification({
			action: () => new OfferClient().addNewOfferAction(params),
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

export const AddOfferForm = AddOfferFormInner;
