import { MDCRadioFoundation } from '@material/radio';
import { MDCRipple } from '@material/ripple';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcListItem extends MDCRipple {

    private input: HTMLInputElement;

    constructor(ref: Element) {
        super(ref);
        this.input = this.root.querySelector<HTMLInputElement>(MDCRadioFoundation.strings.NATIVE_CONTROL_SELECTOR)
    }

    public get checked() {
        return this.input?.checked;
    }

    public set checked(value: boolean) {
        if (this.input) {
            this.input.checked = value;
        }
    }

}

export function init(ref: Element): void {
    mdcInit(ref, new MdcListItem(ref));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function activate(ref: Element): void {    
    mdc<MdcListItem>(ref).activate();
}

export function deactivate(ref: Element): void {
    mdc<MdcListItem>(ref).deactivate();
}

export function getChecked(ref: Element): boolean {
    return mdc<MdcListItem>(ref).checked;
}

export function setChecked(ref: Element, value: boolean): void {
    mdc<MdcListItem>(ref).checked = value;
}

export function getDisabled(ref: Element): boolean {
    return mdc<MdcListItem>(ref).disabled;
}

export function setDisabled(ref: Element, value: boolean): void {
    mdc<MdcListItem>(ref).disabled = value;
}