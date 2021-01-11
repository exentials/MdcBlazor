import { MDCSwitch } from '@material/switch';
import { mdc, mdcDestroy, mdcInit, NATIVE_CHANGE } from '../mdc/mdcBlazor';

class Switch extends MDCSwitch {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen("change", (event) => {
            this.component.invokeMethodAsync<void>(NATIVE_CHANGE, this.checked);
        });        
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new Switch(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getValue(ref: Element) {
    return mdc<Switch>(ref).checked;
}

export function setValue(ref: Element, checked: boolean): void {
    mdc<Switch>(ref).checked = checked;
}

export function getDisabled(ref: Element) {
    return mdc<Switch>(ref).disabled;
}

export function setDisabled(ref: Element, disabled: boolean): void {
    mdc<Switch>(ref).disabled = disabled;
}