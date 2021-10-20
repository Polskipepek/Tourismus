import { IBaseFormikProps } from "./IBaseFormikProps";
import React from "react";
import { Tooltip } from "antd";

class FormikComponentBase extends React.Component<IBaseFormikProps> {
	public render() {
		return <>{this.displayValidationError()}</>;
	}

	displayValidationError() {
		const error = this.props.errors[this.props.name];
		/* console.log(`Component ${this.props.name} ma blad: ${error}`); */
		return (
			<>
				<Tooltip title={error} visible={error !== undefined} placement="right" color="red">
					{this.props.children}
				</Tooltip>
			</>
		);
	}
}

export default FormikComponentBase;
