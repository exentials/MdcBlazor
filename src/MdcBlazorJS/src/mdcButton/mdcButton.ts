import { MDCRipple } from "@material/ripple";
import { mdc, mdcDestroy, mdcInit, native_events } from "../mdc/mdcBlazor";

class MdcButton extends MDCRipple {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen(native_events.CLICK, () => {
            this.component.invokeMethodAsync(native_events.CLICK, null);
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