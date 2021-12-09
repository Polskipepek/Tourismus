import React from "react";
import { IBaseFormikProps } from "../IBaseFormikProps";
import FormikComponentBase from "../FormikComponentBase";
import TextArea from "antd/lib/input/TextArea";

interface ITextAreaFProps {
	placeholder?: string;
	isNumeric?: boolean;
	width?: number | string;
	isPassword?: boolean;
	onChange?: (value: string) => void;
	wrapperAlignCenter?: boolean;
	fontSize?: "h1" | "h2" | "default";
	rows?: number;
}

class TextAreaF extends React.Component<IBaseFormikProps & ITextAreaFProps> {
	public render() {
		const inputValue = this.props.values[this.props.name];
		const titleValue = this.props.isPassword ? "" : inputValue;
		const type = this.props.isPassword ? { type: "password" } : {};

		return (
			<FormikComponentBase {...this.props}>
				<TextArea
					style={{ width: this.props.width }}
					rows={this.props.rows ?? 4}
					placeholder={this.props.placeholder}
					value={inputValue}
					title={titleValue}
					onChange={(event) => this.props.setFieldValue(this.props.name, this.onChange(event.target.value))}
					onBlur={() => this.props.setFieldTouched(this.props.name)}
					disabled={this.props.disabled}
					readOnly={this.props.readonly}
					{...type}
				/>
			</FormikComponentBase>
		);
	}

	private onChange(value: string) {
		if (this.props.isNumeric) {
			return value.replace(/\D/g, "");
		}
		if (this.props.onChange) {
			this.props.onChange(value);
		}
		return value;
	}
}

export default TextAreaF;
