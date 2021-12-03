import { Col, Row } from "antd";
import { Form, FormikBag, FormikProps, withFormik } from "formik";
import React, { useContext } from "react";
import Resources from "../../Resources";
import { AddNewCityParameters, AddNewCountryParameters, CityClient, CountryClient, Country_Dto } from "../../services/GeneratedClient";
import { SendActionWithResponseAndNotification } from "../../_Infrastructure/Actions/SendAction";
import SelectF from "../../_Infrastructure/Formik/Components/SelectF";
import TextInputF from "../../_Infrastructure/Formik/Components/TextInputF";
import { IModalComponentProps } from "../../_Infrastructure/Modals/IModalComponentProps";
import Yup from "../../_Infrastructure/Validation/YupValidation";

interface IAddCityFormProps extends IModalComponentProps {
	closeModal: () => void;
	countries: Country_Dto[];
}

interface IAddCityFormValues {
	cityName: string | undefined; // to idzie z DTO
	countryId: number | undefined;
	isAirport: boolean;
}

class InnerForm extends React.Component<IAddCityFormProps & FormikProps<IAddCityFormValues>> {
	public render() {
		const boolOptions = [
			{
				value: true,
				label: "Jest lotnisko",
			},
			{
				value: false,
				label: "Nie ma lotniska",
			},
		];

		return (
			<Form id="addCity-form" name="addCityForm" className="formStyle">
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.cityName}</Col>
					<Col span={20}>
						<TextInputF {...this.props} name="cityName" placeholder={Resources.InputPlaceholder.cityName} />
					</Col>
				</Row>
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.countryName}</Col>
					<Col span={20}>
						<SelectF {...this.props} name="countryId" width={"100%"} placeholder={Resources.InputPlaceholder.countryName} options={this.props.countries} labelKey="name" valueKey="id" />
					</Col>
				</Row>
				<Row gutter={[8, 16]}>
					<Col span={4}>{Resources.InputPlaceholder.isAirport}</Col>
					<Col span={20}>
						<SelectF {...this.props} name="isAirport" width={"100%"} placeholder={Resources.InputPlaceholder.cityName} options={boolOptions} labelKey="label" valueKey="value" />
					</Col>
				</Row>
			</Form>
		);
	}
}

const validationSchema: Yup.SchemaOf<IAddCityFormValues> = Yup.object({
	cityName: Yup.string().defined().min(3),
	countryId: Yup.number().defined(),
	isAirport: Yup.bool().defined(),
});

const AddCityFormInner = withFormik<IAddCityFormProps, IAddCityFormValues>({
	validateOnChange: false,
	validateOnBlur: false,
	validationSchema: validationSchema,
	mapPropsToValues: (props: IAddCityFormProps) => {
		const mappedProps: IAddCityFormValues = {
			cityName: undefined,
			countryId: undefined,
			isAirport: false,
		};
		return mappedProps;
	},
	handleSubmit: (values: IAddCityFormValues, bag: FormikBag<IAddCityFormProps, IAddCityFormValues>) => {
		var params = new AddNewCityParameters({
			name: values.cityName,
			countryId: Number(values.countryId),
			isAirport: values.isAirport,
		});
		SendActionWithResponseAndNotification({
			action: () => new CityClient().addNewCityAction(params),
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

export const AddCityForm = AddCityFormInner;
