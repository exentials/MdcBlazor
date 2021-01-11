import { MDCTextField } from '@material/textfield';
import { mdc, mdcDestroy, mdcInit, NATIVE_CHANGE } from '../mdc/mdcBlazor';

class TextField extends MDCTextField {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);

        this.listen("change", (evt) => {
            this.component.invokeMethodAsync(NATIVE_CHANGE, this.value);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new TextField(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getValue(ref: Element): string {
    return mdc<TextField>(ref).value;
}

export function setValue(ref: Element, value: string): void {
    mdc<TextField>(ref).value = value || "";
}

export function getDisabled(ref: Element): boolean {
    return mdc<TextField>(ref).disabled;
}

export function setDisabled(ref: Element, value: boolean): void {
    mdc<TextField>(ref).disabled = value;
}