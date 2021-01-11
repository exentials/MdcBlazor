import { MDCRipple } from "@material/ripple";
import { mdc, mdcDestroy, mdcInit, NATIVE_CLICK } from '../mdc/mdcBlazor';

class MdcFab extends MDCRipple {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);

        this.listen("click", () => {
            this.component.invokeMethodAsync(NATIVE_CLICK);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcFab(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function setDisabled(ref: Element, value: boolean): void {
    mdc<MdcFab>(ref).disabled = value;
}