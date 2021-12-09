import React from "react";
import { Input } from "antd";
import { IBaseFormikProps } from "../IBaseFormikProps";
import FormikComponentBase from "../FormikComponentBase";

interface ITextInputFProps {
	placeholder?: string;
	isNumeric?: boolean;
	isPassword?: boolean;
	onChange?: (value: string) => void;
	wrapperAlignCenter?: boolean;
	fontSize?: "h1" | "h2" | "default";
	width?: number | string;
}

class TextInputF extends React.Component<IBaseFormikProps & ITextInputFProps> {
	public render() {
		const inputValue = this.props.values[this.props.name];
		const titleValue = this.props.isPassword ? "" : inputValue;
		const type = this.props.isPassword ? { type: "password" } : {};

		return (
			<FormikComponentBase {...this.props}>
				<Input
					style={{ width: this.props.width }}
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

	private getFontSizeClassName() {
		switch (this.props.fontSize) {
			case "h1":
				return "h1-font-size ";
			case "h2":
				return "h2-font-size ";
			default:
				return "";
		}
	}
}

export default TextInputF;
