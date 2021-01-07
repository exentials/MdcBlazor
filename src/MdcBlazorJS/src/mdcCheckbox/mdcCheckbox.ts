import { MDCCheckbox } from '@material/checkbox';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcCheckbox extends MDCCheckbox {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);

        this.listen("change", (evt) => {            
            this.component.invokeMethodAsync("ChangeFromNative", this.indeterminate ? null : this.checked);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcCheckbox(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getChecked(ref: Element): boolean {
    return mdc<MdcCheckbox>(ref).checked;
}

export function setChecked(ref: Element, value: boolean): void {
    mdc<MdcCheckbox>(ref).checked = value;
}

export function getIndeterminate(ref: Element): boolean {
    return mdc<MdcCheckbox>(ref).indeterminate;
}

export function setIndeterminate(ref: Element, value: boolean): void {
    mdc<MdcCheckbox>(ref).indeterminate = value;
}

export function getDisabled(ref: Element): boolean {
    return mdc<MdcCheckbox>(ref).disabled;
}

export function setDisabled(ref: Element, value: boolean): void {
    mdc<MdcCheckbox>(ref).disabled = value;
}