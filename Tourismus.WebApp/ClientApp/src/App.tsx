import "./App.css";
import HomePage from "./Components/Pages/HomePage";
import { RegisterShopPage } from "./Components/Pages/RegisterShopPage";
import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom";
import ShoppingLayout from "./Components/ShoppingLayout";
import Resources from "./Resources";
import { AboutUsPage } from "./Components/Pages/AboutUsPage";
import UserProfilePage from "./Components/Pages/UserProfilePage";

const App: React.FunctionComponent = () => {
  return (
    <BrowserRouter>
      <ShoppingLayout>
        <Switch>
          <Route path={Resources.AvailablePages.homePage} component={HomePage} />
          <Route path={Resources.AvailablePages.aboutUsPage} component={AboutUsPage} />
          <Route path={Resources.AvailablePages.registerShop} component={RegisterShopPage} />
          <Route path={Resources.AvailablePages.userProfilePage} component={UserProfilePage} />
          <Redirect from="/" to={Resources.AvailablePages.homePage} />
        </Switch>
      </ShoppingLayout>
    </BrowserRouter>
  );
};

export default App;
