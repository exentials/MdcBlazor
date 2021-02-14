import { MDCFormField } from '@material/form-field';
import { MDCRadio } from '@material/radio';
import { mdc, mdcDestroy, mdcInit, native_events } from '../mdc/mdcBlazor';

class MdcRadio extends MDCRadio {
    private _formField: MDCFormField;

    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);

        this.listen(native_events.CLICK, (evt) => {
            this.component.invokeMethodAsync("MDCRadio:change", this.checked);
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
    mdcInit(ref, new MdcRadio(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function initFormField(ref: Element, formFieldRef: Element): void {
    mdc<MdcRadio>(ref).initFormField(mdc<MDCFormField>(formFieldRef));
}

export function getValue(ref: Element): string {
    return mdc<MdcRadio>(ref).value;
}

export function setValue(ref: Element, value: string): void {
    mdc<MdcRadio>(ref).value = value;
}

export function getChecked(ref: Element): boolean {
    return mdc<MdcRadio>(ref).checked;
}

export function setChecked(ref: Element, value: boolean): void {
    mdc<MdcRadio>(ref).checked = value;
}

export function getDisabled(ref: Element): boolean {
    return mdc<MdcRadio>(ref).disabled;
}

export function setDisabled(ref: Element, value: boolean): void {
    mdc<MdcRadio>(ref).disabled = value;
}