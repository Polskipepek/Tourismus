import { BookOutlined, CloseOutlined } from "@ant-design/icons";
import { Button, Modal, Tooltip } from "antd";
import Resources from "../../Resources";
import { IOfferList_Dto, OfferList_Dto } from "../../services/GeneratedClient";
import OfferContentWrapper from "./OfferContent";

interface IOfferModalProps {
	offer: IOfferList_Dto | undefined;
	closeModal: () => void;
	onBookClicked: () => void;
}

const OfferModal: React.FC<IOfferModalProps> = (props) => {
	return (
		<>
			<Modal
				className="Offer-modal"
				title={Resources.ModalHeader.Offer}
				centered
				visible={props.offer != undefined}
				onCancel={() => props.closeModal()}
				destroyOnClose
				footer={[
					<Tooltip title="Zamknij">
						<Button onClick={() => props.closeModal()}>
							<CloseOutlined />
						</Button>
					</Tooltip>,
					<Tooltip title="Bookuj">
						<Button key="submit" htmlType="submit" type="primary" onClick={() => props.onBookClicked()}>
							<BookOutlined />
						</Button>
					</Tooltip>,
				]}>
				<OfferContentWrapper offer={props.offer} />
			</Modal>
		</>
	);
};
export default OfferModal;
