import { MDCSlider, MDCSliderChangeEventDetail } from '@material/slider';
import { mdc, mdcDestroy, mdcInit, NATIVE_CHANGE, NATIVE_INPUT } from '../mdc/mdcBlazor';

class MdcSlider extends MDCSlider {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);       
        this.listen("MDCSlider:change", (event) => {
            console.log("MDCSlider:change", (<any>event));
            // this.component.invokeMethodAsync(NATIVE_CHANGE, this.getValue());
        });

        //this.listen("input", (event) => {
        //    this.component.invokeMethodAsync(NATIVE_INPUT, this.getValue());
        //});
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcSlider(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getValue(ref: Element): number{
    return mdc<MdcSlider>(ref).getValue();
}

export function setValue(ref: Element, value: number): void {
    mdc<MdcSlider>(ref).setValue(value||0);
}

export function getValueStart(ref: Element): number {
    return mdc<MdcSlider>(ref).getValueStart();
}

export function setValueStart(ref: Element, value: number): void {
    mdc<MdcSlider>(ref).setValueStart(value);
}

export function getDisabled(ref: Element): boolean {
    return mdc<MdcSlider>(ref).getDisabled();
}

export function setDisabled(ref: Element, value: boolean): void {
    mdc<MdcSlider>(ref).setDisabled(value);
}