import { MDCRipple } from '@material/ripple';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcListItem extends MDCRipple {
    constructor(ref: Element) {
        super(ref);
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

export function getDisabled(ref: Element): boolean {
    return mdc<MdcListItem>(ref).disabled;
}

export function setDisabled(ref: Element, value: boolean): void {
    mdc<MdcListItem>(ref).disabled = value;
}