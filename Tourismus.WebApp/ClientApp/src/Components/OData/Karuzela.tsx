import { Carousel } from "antd";
import { IOffer_ListDto } from "../../services/ListDtos/Offer_ListDto";

interface IKaruzelaProps {
	data: IOffer_ListDto[];
}

const Karuzela: React.FC<IKaruzelaProps> = (props) => {
	const contentStyle = {
		height: "160px",
		color: "#fff",
		lineHeight: "160px",
		background: "#364d79",
	};

	return (
		<>
			<Carousel>
				{props.data &&
					props.data.map((item) => {
						<div>
							<h3 style={contentStyle}>{item.Id}</h3>
						</div>;
					})}
			</Carousel>
		</>
	);
};

export default Karuzela;
