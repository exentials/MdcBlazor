import { MDCCheckbox } from '@material/checkbox';
import { MDCFormField } from '@material/form-field';
import { mdc, mdcDestroy, mdcInit, native_events } from '../mdc/mdcBlazor';

class MdcCheckboxIndeterminate extends MDCCheckbox {
    private _formField: MDCFormField;

    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);

        this.listen(native_events.CHANGE, (evt) => {
            this.component.invokeMethodAsync("MDCCheckbox:change", this.indeterminate ? null : this.checked);
        });
    }

    public initFormField(formField: MDCFormField) {
        if (formField) {
            this._formField = formField;
            this._formField.input = this;
        }
    }

    destroy() {
        this._formField.input = undefined;
        super.destroy();
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcCheckboxIndeterminate(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function initFormField(ref: Element, formFieldRef: Element): void {
    mdc<MdcCheckboxIndeterminate>(ref).initFormField(mdc<MDCFormField>(formFieldRef));
}

export function getValue(ref: Element): boolean | null {
    const checked = mdc<MdcCheckboxIndeterminate>(ref).checked;
    const indeterminate = mdc<MdcCheckboxIndeterminate>(ref).indeterminate;
    return (indeterminate) ? null : checked;
}

export function setValue(ref: Element, value: boolean | null): void {
    mdc<MdcCheckboxIndeterminate>(ref).checked = !!value;
    mdc<MdcCheckboxIndeterminate>(ref).indeterminate = (value == null);
}

export function getDisabled(ref: Element): boolean {
    return mdc<MdcCheckboxIndeterminate>(ref).disabled;
}

export function setDisabled(ref: Element, value: boolean): void {
    mdc<MdcCheckboxIndeterminate>(ref).disabled = value;
}