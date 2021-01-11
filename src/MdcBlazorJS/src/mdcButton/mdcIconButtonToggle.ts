import { MDCIconButtonToggle, MDCIconButtonToggleEventDetail } from "@material/icon-button";
import { mdc, mdcDestroy, mdcInit, NATIVE_CLICK } from "../mdc/mdcBlazor";

const NATIVE_TOGGLE = "NativeToggle";

class MdcIconButtonToggle extends MDCIconButtonToggle {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen("click", () => {
            this.component.invokeMethodAsync(NATIVE_CLICK);
        });

        this.listen("MDCIconButtonToggle:change", (event) => {
            this.component.invokeMethodAsync(NATIVE_TOGGLE, this.on);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcIconButtonToggle(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getSelect(ref: Element): boolean {
    return mdc<MdcIconButtonToggle>(ref).on;
}

export function setSelect(ref: Element, value: boolean): void {
    mdc<MdcIconButtonToggle>(ref).on = value;
}

export function getDisabled(ref: HTMLButtonElement): boolean {
    return !!ref.disabled;
}

export function setDisabled(ref: HTMLButtonElement, value: boolean): void {
    ref.disabled = value;
}