import { Col, Form, Row } from 'antd';
import { FormikBag, FormikProps, withFormik } from 'formik';
import React from 'react';

import TextInputF from '../../_Infrastructure/Formik/Components/TextInputF';
import { ICustomerDetails_Dto } from '../../services/SingleDto/CustomerDetails_Dto';

type IProfileProps = ICustomerDetails_Dto;
type IProfileValues = IProfileProps;

class InnerForm extends React.Component<IProfileProps & FormikProps<IProfileValues>> {
  public render() {
    return (
      <Form id="profile-form" name="ProfileForm" className="formStyle">
        <Row gutter={[8, 16]}>
          <Col span={24}>
            <TextInputF {...this.props} name="mail" readonly />
          </Col>
          <Col span={24}>
            <TextInputF {...this.props} name="nickname" readonly />
          </Col>
          <Col span={24}>
            <TextInputF {...this.props} name="phoneNumber" readonly />
          </Col>
          <Col span={24}>
            <TextInputF {...this.props} name="reputation" readonly />
          </Col>
        </Row>
      </Form>
    );
  }
}

const ProfileFormInner = withFormik<IProfileProps, IProfileValues>({
  validateOnChange: false,
  validateOnBlur: false,
  mapPropsToValues: (props: IProfileProps) => {
    return props;
  },
  handleSubmit: (values: IProfileValues, bag: FormikBag<IProfileProps, IProfileValues>) => {},
})(InnerForm);

export const ProfileForm = ProfileFormInner;
export default ProfileForm;
