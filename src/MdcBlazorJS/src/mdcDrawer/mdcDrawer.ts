import { MDCDrawer } from "@material/drawer";
import { dotnetInvokeMethodAsync, mdc, mdcDestroy, mdcInit } from "../mdc/mdcBlazor";

class MdcDrawer extends MDCDrawer {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        const navButton = <HTMLButtonElement>document.getElementsByClassName("mdc-top-app-bar__navigation-icon")[0];

        this.listen("MDCDrawer:opening", (event) => {
            
        });

        this.listen("MDCDrawer:opened", (event) => {
            this.component.invokeMethodAsync("MDCDrawer:opened");
        });
        this.listen("MDCDrawer:closed", (event) => {
            if (navButton) {
                navButton.focus();
            }
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
    if (value) {

    }
    mdc<MdcDrawer>(ref).open = value;    
}