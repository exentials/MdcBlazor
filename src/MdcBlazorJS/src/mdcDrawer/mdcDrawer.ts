import { MDCDrawer } from "@material/drawer";
import { dotnetInvokeMethodAsync, mdc, mdcDestroy, mdcInit } from "../mdc/mdcBlazor";

class MdcDrawer extends MDCDrawer {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen("MDCDrawer:opened", (event) => {
            this.component.invokeMethodAsync("MDCDrawer:opened");
        });
        this.listen("MDCDrawer:closed", (event) => {
            this.component.invokeMethodAsync("MDCDrawer:closed");
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject) {
    mdcInit(ref, new MdcDrawer(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getOpen(ref: Element): boolean {
    return mdc<MdcDrawer>(ref).open;
}

export function setOpen(ref: Element, value: boolean): void {
    mdc<MdcDrawer>(ref).open = value;
}