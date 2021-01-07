import { MDCRipple } from "@material/ripple";
import { mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MDCFab extends MDCRipple {
    constructor(ref:Element) {
        super(ref);
    }
}

export function init(ref: Element): void {
    mdcInit(ref, new MDCFab(ref));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}