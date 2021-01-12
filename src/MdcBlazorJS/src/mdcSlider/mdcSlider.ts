import { MDCSlider, MDCSliderChangeEventDetail } from '@material/slider';
import { mdc, mdcDestroy, mdcInit, NATIVE_CHANGE, NATIVE_INPUT } from '../mdc/mdcBlazor';

class MdcSlider extends MDCSlider {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);       
        //this.listen("change", (event) => {
        //    this.component.invokeMethodAsync(NATIVE_CHANGE, this.getValue());
        //});

        //this.listen("input", (event) => {
        //    this.component.invokeMethodAsync(NATIVE_INPUT, this.getValue());
        //});
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MDCSlider(ref));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getValue(ref: Element): number{
    return mdc<MDCSlider>(ref).getValue();
}

export function setValue(ref: Element, value: number): void {
    mdc<MDCSlider>(ref).setValue(value||0);
}

export function getValueStart(ref: Element): number {
    return mdc<MDCSlider>(ref).getValueStart();
}

export function setValueStart(ref: Element, value: number): void {
    mdc<MDCSlider>(ref).setValueStart(value);
}

export function getDisabled(ref: Element): boolean {
    return mdc<MDCSlider>(ref).getDisabled();
}

export function setDisabled(ref: Element, value: boolean): void {
    mdc<MDCSlider>(ref).setDisabled(value);
}