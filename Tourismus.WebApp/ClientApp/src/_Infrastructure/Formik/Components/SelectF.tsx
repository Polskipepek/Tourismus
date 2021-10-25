import React from "react";
import { IBaseFormikProps } from "../IBaseFormikProps";
import FormikComponentBase from "../FormikComponentBase";
import { Select } from "antd";

interface IOptionProps {
  key: number;
  value: string;
}

interface ISelectFProps<T> {
  labelKey: string;
  valueKey: string;
  width?: number | string;
  mode?: "multiple" | "tags" | undefined;
  placeholder?: string;
  isPassword?: boolean;
  isNumeric?: boolean;
  wrapperAlignCenter?: boolean;
  fontSize?: "h1" | "h2" | "default";
  onChange?: (value: string) => void;
  options?: any[];
}

class SelectF<T> extends React.Component<IBaseFormikProps & ISelectFProps<T>> {
  public render() {
    const inputValue = this.props.values[this.props.name];
    const { Option } = Select;

    let selectOptons: IOptionProps[] = [];
    this.props.options?.map((option) => {
      let optionValue = {
        key: option[this.props.valueKey],
        value: option[this.props.labelKey],
      };
      selectOptons.push(optionValue);
    });

    return (
      <>
        <FormikComponentBase {...this.props}>
          <Select mode={this.props.mode} value={inputValue} style={{ width: this.props.width }} id={this.props.name} onChange={(event) => this.props.setFieldValue(this.props.name, this.onChange(event))} onBlur={() => this.props.setFieldTouched(this.props.name)}>
            {selectOptons?.map((option) => (
              <>
                <Option key={option.key} value={option.key}>
                  {option.value}
                </Option>
              </>
            ))}
          </Select>
        </FormikComponentBase>
      </>
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

export default SelectF;
