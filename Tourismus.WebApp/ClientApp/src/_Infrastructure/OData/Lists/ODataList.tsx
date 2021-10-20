import { ODataListType } from "./ODataListType";
import React from "react";
import buildQuery from "odata-query";
import { openErrorNotification } from "../../../Helpers/NotificationHelper";
import Resources from "../../../Resources";

export interface IODataListProps {
	oDataListType: ODataListType;
	filter: any;
	render(data: Array<any>): void;
}

interface IODataInternalState {
	data: any | undefined;
}

export class ODataList extends React.Component<IODataListProps, IODataInternalState> {
	constructor(props: IODataListProps) {
		super(props);
		this.state = {
			data: undefined,
		};
	}

	componentDidMount() {
		this.fetchOdata();
	}

	private fetchOdata() {
		const query = { filter: this.props.filter };
		const url = `${process.env.REACT_APP_API_ODATA_ADRESS}/${this.props.oDataListType}/GetList${buildQuery(query)}`;

		fetch(url)
			.then((response) => response.json())
			.then((data) => {
				this.setState({ data });
			})
			.catch((error) => {
				openErrorNotification(Resources.Notifications.odata_getListErrorTitle, ``);
			});
	}

	render() {
		return <>{this.state.data != undefined && this.props.render(this.state.data.value)}</>;
	}
}
