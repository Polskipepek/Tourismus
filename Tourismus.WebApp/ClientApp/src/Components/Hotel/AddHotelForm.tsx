import { StarFilled, StarOutlined } from "@ant-design/icons";
import { Col, Row } from "antd";
import { Form, FormikBag, FormikProps, withFormik } from "formik";
import React from "react";
import { nameof } from "ts-simple-nameof";
import Resources from "../../Resources";
import { AddNewHotelParameters, HotelClient, IHotel_Dto, IAddNewHotelParameters as IFormValues } from "../../services/GeneratedClient";
import { SendActionWithResponseAndNotification } from "../../_Infrastructure/Actions/SendAction";
import SelectF from "../../_Infrastructure/Formik/Components/SelectF";
import TextAreaF from "../../_Infrastructure/Formik/Components/TextAreaF";
import TextInputF from "../../_Infrastructure/Formik/Components/TextInputF";
import { IModalComponentProps } from "../../_Infrastructure/Modals/IModalComponentProps";
import Yup from "../../_Infrastructure/Validation/YupValidation";

interface IAddHotelFormProps extends IModalComponentProps {
	closeModal: () => void;
}

class InnerForm extends React.Component<IAddHotelFormProps & FormikProps<IFormValues>> {
	public render() {
		return (
			<Form id="addHotel-form" name="addHotelForm" className="formStyle">
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.hotelId}</Col>
					<Col span={20}>
						<TextInputF {...this.props} name={nameof<IFormValues>((x) => x.name)} placeholder={Resources.InputPlaceholder.hotelId} />
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
					<Col span={4}>{Resources.InputPlaceholder.star}</Col>
					<Col span={20}>
						<SelectF {...this.props} options={starOptions} width={"100%"} labelKey="label" valueKey="value" name={nameof<IFormValues>((x) => x.star)} placeholder={Resources.InputPlaceholder.star} />
					</Col>
				</Row>
				<br />
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.photoPaths}</Col>
					<Col span={20}>
						<TextInputF {...this.props} name={nameof<IFormValues>((x) => x.photosPaths)} placeholder={Resources.InputPlaceholder.price} />
					</Col>
				</Row>
			</Form>
		);
	}
}

const validationSchema: Yup.SchemaOf<IFormValues> = Yup.object({
	name: Yup.string().defined().min(3),
	cityId: Yup.number().defined(),
	star: Yup.number().defined(),
	description: Yup.string().defined().min(10),
	photosPaths: Yup.string(),
});

const AddHotelFormInner = withFormik<IAddHotelFormProps, IFormValues>({
	validateOnChange: false,
	validateOnBlur: false,
	validationSchema: validationSchema,
	mapPropsToValues: (props: IAddHotelFormProps) => {
		const mappedProps: IFormValues = {
			name: undefined,
			cityId: 0,
			description: undefined,
			star: 0,
			photosPaths: undefined,
		};
		return mappedProps;
	},
	handleSubmit: (values: IFormValues, bag: FormikBag<IAddHotelFormProps, IFormValues>) => {
		var params = new AddNewHotelParameters({
			name: values.name,
			cityId: values.cityId,
			description: values.description,
			star: values.star,
			photosPaths: values.photosPaths,
		});
		SendActionWithResponseAndNotification({
			action: () => new HotelClient().addNewHotelAction(params),
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

export const AddHotelForm = AddHotelFormInner;

export const starOptions = [
	{
		value: 1,
		label: (
			<>
				<StarFilled />
				<StarOutlined />
				<StarOutlined />
				<StarOutlined />
				<StarOutlined />
			</>
		),
	},
	{
		value: 2,
		label: (
			<>
				<StarFilled />
				<StarFilled />
				<StarOutlined />
				<StarOutlined />
				<StarOutlined />
			</>
		),
	},
	{
		value: 3,
		label: (
			<>
				<StarFilled />
				<StarFilled />
				<StarFilled />
				<StarOutlined />
				<StarOutlined />
			</>
		),
	},
	{
		value: 4,
		label: (
			<>
				<StarFilled />
				<StarFilled />
				<StarFilled />
				<StarFilled />
				<StarOutlined />
			</>
		),
	},
	{
		value: 5,
		label: (
			<>
				<StarFilled />
				<StarFilled />
				<StarFilled />
				<StarFilled />
				<StarFilled />
			</>
		),
	},
];
