import { MDCRipple } from "@material/ripple";
import { mdc, mdcDestroy, mdcInit, native_events } from "../mdc/mdcBlazor";

class MdcIconButton extends MDCRipple {
    constructor(private ref: HTMLButtonElement, private component: DotNet.DotNetObject) {
        super(ref);      
        this.unbounded = true;
        this.listen(native_events.CLICK, () => {
            this.component.invokeMethodAsync(native_events.CLICK);
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
    return ref.disabled;
}

export function setDisabled(ref: HTMLButtonElement, value: boolean): void {
    ref.disabled = value;
}