import { strings, MDCSelect, MDCSelectEvent } from '@material/select';
import { mdc, mdcDestroy, mdcInit, native_events } from '../mdc/mdcBlazor';

class MdcSelect extends MDCSelect {

    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);

        this.listen(strings.CHANGE_EVENT, (event: MDCSelectEvent) => {
            this.component.invokeMethodAsync(native_events.CHANGE, event.detail.value);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcSelect(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getValue(ref: Element): string {
    return mdc<MdcSelect>(ref).value;
}

export function setValue(ref: Element, value: string): void {
    mdc<MdcSelect>(ref).value = value;
}

export function getIndex(ref: Element): number {
    return mdc<MdcSelect>(ref).selectedIndex;
}

export function setIndex(ref: Element, value: number): void {
    mdc<MdcSelect>(ref).selectedIndex = value;
}

export function getDisabled(ref: Element): boolean {
    return mdc<MdcSelect>(ref).disabled;
}

export function setDisabled(ref: Element, value: boolean): void {
    mdc<MdcSelect>(ref).disabled = value;
}

export function getRequired(ref: Element): boolean {
    return mdc<MdcSelect>(ref).required;
}

export function setRequired(ref: Element, value: boolean): void {
    mdc<MdcSelect>(ref).required = value;
}