import { FormikErrors, FormikTouched, FormikValues } from 'formik';

export interface IBaseFormikProps {
    values: FormikValues,
    errors: FormikErrors<FormikValues>,
    handleSubmit: (e?: React.FormEvent<HTMLFormElement>) => void,
    setFieldValue: (field: keyof FormikValues & string, value: any, shouldValidate?: boolean) => void,
    setFieldTouched: (field: keyof FormikValues & string, isTouched?: boolean, shouldValidate?: boolean) => void,
    name: string,
    required?: boolean;
    touched: FormikTouched<FormikValues>;
    disabled?: boolean | undefined;
    allowClear?: boolean;
    forceUpdateKey?: number;
    readonly?: boolean;
    shouldUpdateComponentCheckInChildren?: boolean;
    additionalWrapperClassName?: string;
    pooverTitle?: React.ReactNode;
    pooverContent?: React.ReactNode;
}
