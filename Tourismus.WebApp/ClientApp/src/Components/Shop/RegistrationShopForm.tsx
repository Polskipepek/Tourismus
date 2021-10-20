import { Button, Col, Row } from "antd";
import { Form, FormikBag, FormikProps, withFormik } from "formik";
import React from "react";
import Resources from "../../Resources";
import { AddNewShopAction, ImageData, ShopClient } from "../../services/GeneratedClient";
import { IShopCategories_ListDto } from "../../services/ListDtos/ShopCategories_ListDto";
import { SendActionWithResponseAndNotification } from "../../_Infrastructure/Actions/SendAction";
import TextAreaF from "../../_Infrastructure/Formik/Components/TextAreaF";
import TextInputF from "../../_Infrastructure/Formik/Components/TextInputF";
import { Select } from "antd";
import FormikComponentBase from "../../_Infrastructure/Formik/FormikComponentBase";
import { ODataList } from "../../_Infrastructure/OData/Lists/ODataList";
import { ODataListType } from "../../_Infrastructure/OData/Lists/ODataListType";
import Yup from "../../_Infrastructure/Validation/YupValidation";
import SelectF from "../../_Infrastructure/Formik/Components/SelectF";

interface IRegisterShopProps {}

interface IImageData {
  name: string | undefined;
  uri: string | undefined;
}

interface IRegisterShopValues {
  name: string | undefined;
  description: string | undefined;
  nip: string | undefined;
  regon: string | undefined;
  krs: string | undefined;
  street: string | undefined;
  zipcode: string | undefined;
  city: string | undefined;
  categoryId: number[] | undefined;
  image: IImageData | undefined;
}
const { Option } = Select;

class InnerForm extends React.Component<IRegisterShopProps & FormikProps<IRegisterShopValues>> {
  public render() {
    return (
      <>
        <Form id="register-shop-form" name="RegisterShopForm" className="formStyle">
          <Row gutter={[8, 16]}>
            <Col span={24}>
              <h4>{Resources.RegistrationShopForm.labelName}</h4>
              <TextInputF {...this.props} name="name" />
            </Col>
          </Row>
          <Row gutter={[8, 16]}>
            <Col span={24}>
              <h4>{Resources.RegistrationShopForm.labelDescription}</h4>
              <TextAreaF {...this.props} name="description" />
            </Col>
          </Row>
          <Row gutter={[8, 16]}>
            <Col span={8}>
              <h4>{Resources.RegistrationShopForm.labelNIPNumber}</h4>
              <TextInputF {...this.props} name="nip" />
            </Col>
            <Col span={8}>
              <h4>{Resources.RegistrationShopForm.labelRegonNumber}</h4>
              <TextInputF {...this.props} name="regon" />
            </Col>
            <Col span={8}>
              <h4>{Resources.RegistrationShopForm.labelKRSNumber}</h4>
              <TextInputF {...this.props} name="krs" />
            </Col>
          </Row>
          <Row gutter={[8, 16]}>
            <Col span={8}>
              <h4>{Resources.RegistrationShopForm.labelStreet}</h4>
              <TextInputF {...this.props} name="street" />
            </Col>
            <Col span={8}>
              <h4>{Resources.RegistrationShopForm.labelZipCode}</h4>
              <TextInputF {...this.props} name="zipcode" />
            </Col>
            <Col span={8}>
              <h4>{Resources.RegistrationShopForm.labelCity}</h4>
              <TextInputF {...this.props} name="city" />
            </Col>
          </Row>
          <Row gutter={[8, 16]}>
            <Col span={12}>
              <h4>{Resources.RegistrationShopForm.labelUrl}</h4>
              <TextInputF {...this.props} name="image.uri" />
            </Col>
            <Col span={12}>
              <h4>{Resources.RegistrationShopForm.labelShopCategory}</h4>
              <ODataList
                {...this.props}
                oDataListType={ODataListType.ShopCategories}
                filter={{}}
                render={(data: IShopCategories_ListDto[]) => (
                  <>
                    <SelectF mode="multiple" width={"100%"} {...this.props} labelKey="Name" valueKey="Id" options={data} name="categoryId" />
                  </>
                )}
              />
            </Col>
          </Row>
          <Button form="register-shop-form" key="submit" htmlType="submit" onSubmit={this.props.handleSubmit} type="primary" style={{ marginTop: 20 }}>
            {Resources.RegistrationShopForm.btnRegisterShop}
          </Button>
        </Form>
      </>
    );
  }
}

const validationSchema: Yup.SchemaOf<IRegisterShopValues> = Yup.object({
  name: Yup.string().defined(),
  description: Yup.string().defined(),
  nip: Yup.string().defined(),
  city: Yup.string().defined(),
  krs: Yup.string().defined(),
  regon: Yup.string().defined(),
  street: Yup.string().defined(),
  zipcode: Yup.string().defined(),
  categoryId: Yup.mixed().defined(),
  image: Yup.mixed().notRequired(),
});

const RegistrationShopFormInner = withFormik<IRegisterShopProps, IRegisterShopValues>({
  validateOnChange: false,
  validateOnBlur: false,
  validationSchema: validationSchema,
  mapPropsToValues: (props: IRegisterShopProps) => {
    const mappedProps: IRegisterShopValues = {
      name: undefined,
      description: undefined,
      nip: undefined,
      city: undefined,
      krs: undefined,
      regon: undefined,
      street: undefined,
      zipcode: undefined,
      categoryId: undefined,
      image: undefined,
    };
    return mappedProps;
  },
  handleSubmit: (values: IRegisterShopValues, bag: FormikBag<IRegisterShopProps, IRegisterShopValues>) => {
    var imageParams = new ImageData({
      name: "Logo",
      uri: values.image?.uri,
      id: 0,
    });

    var params = new AddNewShopAction({
      name: values.name,
      description: values.description,
      krs: values.krs,
      nip: values.nip,
      city: values.city,
      image: imageParams,
      categoriesId: values.categoryId,
      products: undefined,
      regon: values.regon,
      street: values.street,
      zipCode: values.zipcode,
    });

    SendActionWithResponseAndNotification({
      action: () => new ShopClient().addNewShopAction(params),
      onSuccess: (resp) => {
        bag.resetForm();
      },
      successTitle: Resources.Notifications.registrationShopForm_SuccessTitle,
      successMessage: Resources.Notifications.registrationShopForm_SuccessMessage,
      failureTitle: Resources.Notifications.registrationShopForm_failureTitle,
      failureMessage: Resources.Notifications.registrationShopForm_failureMessage,
    });
  },
})(InnerForm);

export const RegistrationShopForm = RegistrationShopFormInner;
