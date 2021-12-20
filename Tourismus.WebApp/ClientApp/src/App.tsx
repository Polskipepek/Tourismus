import "./App.css";
import HomePage from "./Components/Pages/HomePage";
import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom";
import MainLayout from "./Components/MainLayout";
import Resources from "./Resources";
import { AboutUsPage } from "./Components/Pages/AboutUsPage";
import UserProfilePage from "./Components/Pages/UserProfilePage";
import { IUser } from "./services/GeneratedClient";
import { createContext, useContext, useEffect, useState } from "react";
import AdminDashboardPage from "./Components/Pages/AdminDashboardPage";

const usePersistentState = (key: string, defaultValue: any) => {
	const _key = `persistent_state_${key}`;
	const [getPersistentState, setPersistentState] = useState(() => {
		var storageItem = localStorage.getItem(_key);
		if (storageItem) {
			try {
				return JSON.parse(storageItem);
			} catch {
				return defaultValue;
			}
		}
		return defaultValue;
	});

	useEffect(() => {
		localStorage.setItem(_key, JSON.stringify(getPersistentState));
	}, [key, getPersistentState]);
	return [getPersistentState, setPersistentState];
};

export interface IPersistentState {
	usePersistentState: (key: string, defaultValue: any) => any[];
}

export interface IAppContext {
	toggleUser: ((newAppUser: IUser | undefined) => void) | undefined;
	user: IUser | undefined;
	refreshPage: (() => void) | undefined;
}

export const PersistentStateContext = createContext<IPersistentState>({ usePersistentState: usePersistentState });

const defaultAppContext: IAppContext = {
	toggleUser: undefined,
	user: undefined,
	refreshPage: undefined,
};

export const AppContext = createContext<IAppContext>(defaultAppContext);

const App: React.FunctionComponent = () => {
	const { usePersistentState } = useContext<IPersistentState>(PersistentStateContext);
	const [user, setUser] = usePersistentState(Resources.persistentKeys.User, undefined);
	const [refresh, setRefresh] = useState<boolean>(false);

	useEffect(() => {
		CheckIfAuthorized();
		console.log(user);
	}, []);

	const refreshPage = () => setRefresh(!refresh);
	const toggleUser = (newAppUser: IUser | undefined) => setUser(newAppUser);

	const CheckIfAuthorized = () => {
		/* 		new UserClient()
			.authorize()
			.then((appUser) => {
				toggleAppUser(appUser ? appUser : undefined);
			})
			.catch((ex) => {
				if (SwaggerException.isSwaggerException(ex) && (ex as SwaggerException).status === 401) {
					toggleAppUser(undefined);
				}
			}); */
	};

	return (
		<BrowserRouter>
			<AppContext.Provider value={{ user, toggleUser, refreshPage }}>
				<MainLayout>
					<Switch>
						<Route path={Resources.AvailablePages.homePage} component={HomePage} />
						<Route path={Resources.AvailablePages.aboutUsPage} component={AboutUsPage} />
						{user && <Route path={Resources.AvailablePages.userProfilePage} component={UserProfilePage} />}
						{user && user.isAdmin && <Route path={Resources.AvailablePages.adminDashboardPage} component={AdminDashboardPage} />}
						<Redirect from="/" to={Resources.AvailablePages.homePage} />
					</Switch>
				</MainLayout>
			</AppContext.Provider>
		</BrowserRouter>
	);
};

export default App;
