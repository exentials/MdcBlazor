import { MDCDrawer } from "@material/drawer";
import { dotnetInvokeMethodAsync, mdc, mdcDestroy, mdcInit } from "../mdc/mdcBlazor";

class MdcDrawer extends MDCDrawer {
    constructor(ref: Element) {
        super(ref);
        this.listen("MDCDrawer:closed", async () => {
            await dotnetInvokeMethodAsync("MDCDrawerClosedHandler");
        });
        this.listen("MDCDrawer:opened", async () => {
            await dotnetInvokeMethodAsync("MDCDrawerOpenedHandler");
        });
    }
}

export function init(ref: Element) {
    mdcInit(ref, new MdcDrawer(ref));
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