import './register.css';

import { Button, Modal } from 'antd';

import { CheckCircleTwoTone } from '@ant-design/icons';

import { IModalComponentProps } from '../../../_Infrastructure/Modals/IModalComponentProps';
import Resources from '../../../Resources';
import { RegisterForm } from './RegisterForm';

interface IRegisterProps extends IModalComponentProps {
  modalVisible: boolean;
}

export const RegisterModal: React.FunctionComponent<IRegisterProps> = (props) => {
  return (
    <>
      <Modal
        className="register-modal"
        title={Resources.PageHeader.registerPage}
        centered
        visible={props.modalVisible}
        onCancel={() => props.closeModal()}
        destroyOnClose
        footer={[
          <Button form="register-form" key="submit" htmlType="submit" type="primary">
            <CheckCircleTwoTone />
          </Button>,
        ]}
      >
        <RegisterForm {...props} />
      </Modal>
    </>
  );
};
