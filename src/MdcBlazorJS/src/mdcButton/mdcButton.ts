import { MDCRipple } from "@material/ripple";
import { mdcDestroy, mdcInit } from "../mdc/mdcBlazor";

class MdcButton extends MDCRipple {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcButton(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}