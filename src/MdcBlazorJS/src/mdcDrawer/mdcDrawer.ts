import { strings, MDCDrawer } from "@material/drawer";
import { mdc, mdcDestroy, mdcInit } from "../mdc/mdcBlazor";

class MdcDrawer extends MDCDrawer {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        const navButton = <HTMLButtonElement>document.getElementsByClassName("mdc-top-app-bar__navigation-icon")[0];
        
        this.listen(strings.OPEN_EVENT, (event) => {
            this.component.invokeMethodAsync(strings.OPEN_EVENT);
        });
        this.listen(strings.CLOSE_EVENT, (event) => {
            if (navButton) {
                navButton.focus();
            }
            this.component.invokeMethodAsync(strings.CLOSE_EVENT);
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