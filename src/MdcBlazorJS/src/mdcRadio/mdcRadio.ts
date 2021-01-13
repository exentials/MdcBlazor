import { MDCRadio } from '@material/radio';
import { mdc, mdcDestroy, mdcInit, NATIVE_CHANGE } from '../mdc/mdcBlazor';

class MdcRadio extends MDCRadio {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);

        this.listen("change", (evt) => {
            this.component.invokeMethodAsync(NATIVE_CHANGE, this.checked);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcRadio(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getValue(ref: Element): string {
    return mdc<MdcRadio>(ref).value;
}

export function setValue(ref: Element, value: string): void {
    mdc<MdcRadio>(ref).value = value;
}

export function getChecked(ref: Element): boolean {
    return mdc<MdcRadio>(ref).checked;
}

export function setCheked(ref: Element, value: boolean): void {
    mdc<MdcRadio>(ref).checked = value;
}

export function getDisabled(ref: Element): boolean {
    return mdc<MdcRadio>(ref).disabled;
}

export function setDisabled(ref: Element, value: boolean): void {
    mdc<MdcRadio>(ref).disabled = value;
}