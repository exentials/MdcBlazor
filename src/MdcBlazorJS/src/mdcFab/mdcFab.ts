import { MDCRipple } from "@material/ripple";
import { mdc, mdcDestroy, mdcInit, native_events } from '../mdc/mdcBlazor';

class MdcFab extends MDCRipple {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);

        this.listen(native_events.CLICK, () => {
            this.component.invokeMethodAsync(native_events.CLICK);
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