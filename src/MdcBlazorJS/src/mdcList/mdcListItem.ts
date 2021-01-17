import { MDCRipple } from '@material/ripple';
import { mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

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