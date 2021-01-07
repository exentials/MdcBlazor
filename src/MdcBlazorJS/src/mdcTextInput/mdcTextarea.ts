import { MDCTextField } from '@material/textfield';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class TextArea extends MDCTextField {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);

        this.listen("change", (evt) => {
            this.component.invokeMethodAsync("ChangeFromNative", this.value);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new TextArea(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getValue(ref: Element): string {
    return mdc<TextArea>(ref).value;
}

export function setValue(ref: Element, value: string): void {
    mdc<TextArea>(ref).value = value || "";
}

export function getDisabled(ref: Element): boolean {
    return mdc<TextArea>(ref).disabled;
}

export function setDisabled(ref: Element, value: boolean): void {
    mdc<TextArea>(ref).disabled = value;
}