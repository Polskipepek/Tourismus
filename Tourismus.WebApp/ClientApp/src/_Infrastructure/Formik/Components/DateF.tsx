import React from "react";
import { DatePicker, Input } from "antd";
import { IBaseFormikProps } from "../IBaseFormikProps";
import FormikComponentBase from "../FormikComponentBase";
import { Moment } from "moment";

interface IDateFProps {
	placeholder?: string;
	onChange?: (value: Date) => void;
	width?: number | string;
	picker: "date" | "week" | "month" | "quarter" | "year";
}

class DateF extends React.Component<IBaseFormikProps & IDateFProps> {
	public render() {
		return (
			<FormikComponentBase {...this.props}>
				<DatePicker style={{ width: this.props.width }} picker={this.props.picker} onChange={(v) => this.props.onChange && v != null && this.props.onChange(v.toDate())} />
			</FormikComponentBase>
		);
	}
}

export default DateF;
