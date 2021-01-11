import { MDCSelectIcon } from '@material/select/icon';
import { mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcIcon extends MDCSelectIcon {
    constructor(ref: Element) {
        super(ref);
    }
}

export function init(ref: Element): void {
    mdcInit(ref, new MdcIcon(ref));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}