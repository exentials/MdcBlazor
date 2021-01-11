import { MDCRipple } from "@material/ripple";
import { mdc, mdcDestroy, mdcInit, NATIVE_CLICK } from "../mdc/mdcBlazor";

class MdcIconButton extends MDCRipple {
    constructor(private ref: HTMLButtonElement, private component: DotNet.DotNetObject) {
        super(ref);      
        this.unbounded = true;
        this.listen("click", () => {
            this.component.invokeMethodAsync(NATIVE_CLICK);
        });
    }
}

export function init(ref: HTMLButtonElement, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcIconButton(ref, component));
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