import { MDCList } from "@material/list";
import { mdcDestroy, mdcInit } from "../mdc/mdcBlazor";

class MdcDrawerNav extends MDCList {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.wrapFocus = true;
    }
}

export function init(ref: Element, component: DotNet.DotNetObject) {
    mdcInit(ref, new MdcDrawerNav(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}