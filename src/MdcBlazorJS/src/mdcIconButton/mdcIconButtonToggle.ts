import { strings, MDCIconButtonToggle, MDCIconButtonToggleEventDetail } from "@material/icon-button";
import { mdc, mdcDestroy, mdcInit, native_events } from "../mdc/mdcBlazor";

class MdcIconButtonToggle extends MDCIconButtonToggle {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        //this.listen(native_events.CLICK, () => {
        //    this.component.invokeMethodAsync(native_events.CLICK);
        //});

        this.listen(strings.CHANGE_EVENT, (event) => {
            this.component.invokeMethodAsync(strings.CHANGE_EVENT, this.on);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcIconButtonToggle(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getSelect(ref: Element): boolean {
    return mdc<MdcIconButtonToggle>(ref).on;
}

export function setSelect(ref: Element, value: boolean): void {
    mdc<MdcIconButtonToggle>(ref).on = value;
}

export function getDisabled(ref: HTMLButtonElement): boolean {
    return !!ref.disabled;
}

export function setDisabled(ref: HTMLButtonElement, value: boolean): void {
    ref.disabled = value;
}