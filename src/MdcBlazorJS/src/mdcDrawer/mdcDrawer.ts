import { MDCDrawer } from "@material/drawer";
import { dotnetInvokeMethodAsync, mdc, mdcDestroy, mdcInit } from "../mdc/mdcBlazor";

export function init(ref: Element) {
    const mdcComponent = mdcInit(ref, new MDCDrawer(ref));

    mdcComponent.listen("MDCDrawer:closed", async () => {
        await dotnetInvokeMethodAsync("MDCDrawerClosedHandler");
    });
    mdcComponent.listen("MDCDrawer:opened", async () => {
        await dotnetInvokeMethodAsync("MDCDrawerOpenedHandler");
    });
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getOpen(ref: Element): boolean {
    return mdc<MDCDrawer>(ref).open;
}

export function setOpen(ref: Element, value: boolean): void {
    mdc<MDCDrawer>(ref).open = value;
}
