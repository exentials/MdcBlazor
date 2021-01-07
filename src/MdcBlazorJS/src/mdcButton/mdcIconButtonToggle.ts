import { MDCIconButtonToggle } from "@material/icon-button";
import { mdc, mdcDestroy, mdcInit } from "../mdc/mdcBlazor";

class IconButtonToggle extends MDCIconButtonToggle {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);

        this.listen("click", () => {
            this.component.invokeMethodAsync("ChangeFromNative", this.on);
        });
    }

}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new IconButtonToggle(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getSelect(ref: Element): boolean {
    return mdc<IconButtonToggle>(ref).on;
}

export function setSelect(ref: Element, value: boolean): void {
    mdc<IconButtonToggle>(ref).on = value;
}