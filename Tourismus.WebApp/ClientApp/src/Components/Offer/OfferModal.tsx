import { Modal } from "antd";
import Resources from "../../Resources";
import { OfferList_Dto } from "../../services/GeneratedClient";
import OfferContentWrapper from "./OfferContent";

interface IOfferModalProps {
	offer: OfferList_Dto | undefined;
	closeModal: () => void;
}

const OfferModal: React.FC<IOfferModalProps> = (props) => {
	return (
		<>
			<Modal className="Offer-modal" title={Resources.ModalHeader.Offer} centered visible={props.offer != undefined} onCancel={() => props.closeModal()} destroyOnClose>
				<OfferContentWrapper offer={props.offer} />
			</Modal>
		</>
	);
};
export default OfferModal;
