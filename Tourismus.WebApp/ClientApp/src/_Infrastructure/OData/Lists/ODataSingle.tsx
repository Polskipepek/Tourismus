import { ODataSingleType } from "./ODataSingleType";
import React from "react";
import buildQuery from "odata-query";
import { openErrorNotification } from "../../../Helpers/NotificationHelper";
import Resources from "../../../Resources";

export interface IODataSingleProps {
	oDataSingleType: ODataSingleType;
	filter: any;
	render(data: any): void;
}

interface IODataInternalState {
	data: any | undefined;
}

export class ODataSingle extends React.Component<IODataSingleProps, IODataInternalState> {
	constructor(props: IODataSingleProps) {
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
		const url = `${process.env.REACT_APP_API_ODATA_ADRESS}/${this.props.oDataSingleType}${buildQuery(query)}`;

		fetch(url)
			.then((response) => response.json())
			.then((data) => {
				this.setState({ data });
			})
			.catch((error) => {
				openErrorNotification(Resources.Notifications.odata_getSingleErrorTitle, ``);
			});
	}

	render() {
		return <>{this.state.data != undefined && this.props.render(this.state.data)}</>;
	}
}
