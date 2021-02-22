import { MDCRipple } from "@material/ripple";
import {  mdcDestroy, mdcInit, native_events } from "../mdc/mdcBlazor";

class MdcDataTablePaginationButton extends MDCRipple {
    constructor(private ref: HTMLButtonElement, private component: DotNet.DotNetObject) {
        super(ref);
        this.unbounded = true;
        this.listen(native_events.CLICK, () => {
            this.component.invokeMethodAsync(native_events.CLICK);
        });
    }
}

export function init(ref: HTMLButtonElement, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcDataTablePaginationButton(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}