import { Card, Table } from "antd";
import Meta from "antd/lib/card/Meta";
import { IShop_ListDto } from "../../../services/ListDtos/Shop_ListDto";
interface IShopCardsProps {
  data: IShop_ListDto[];
}

const ShopCards: React.FunctionComponent<IShopCardsProps> = (props) => {
  let counter = 0;

  return (
    <>
      {props.data.map((shop) => {
        return (
          <>
            <Card style={{ width: 300, display: "inline-block" }} cover={<img alt="shop-picture" src={shop.ImageUrl} />}>
              <Meta title={shop.Name} description={shop.Description} />
            </Card>
          </>
        );
      })}
      ;
    </>
  );
};

export default ShopCards;
