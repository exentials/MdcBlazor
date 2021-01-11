import { MDCRipple } from "@material/ripple";
import { mdc, mdcDestroy, mdcInit, NATIVE_CLICK } from "../mdc/mdcBlazor";

class MdcButton extends MDCRipple {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen("click", () => {
            this.component.invokeMethodAsync(NATIVE_CLICK, null);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcButton(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getDisabled(ref: HTMLButtonElement): boolean {
    return !!ref.disabled;
}

export function setDisabled(ref: HTMLButtonElement, value: boolean): void {
    ref.disabled = value;
}