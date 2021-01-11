import { MDCCheckbox } from '@material/checkbox';
import { mdc, mdcDestroy, mdcInit, NATIVE_CHANGE } from '../mdc/mdcBlazor';

class MdcCheckbox extends MDCCheckbox {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);

        this.listen("change", (evt) => {
            this.component.invokeMethodAsync(NATIVE_CHANGE, this.indeterminate ? null : this.checked);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcCheckbox(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getValue(ref: Element): boolean | null {
    const checked = mdc<MdcCheckbox>(ref).checked;
    const indeterminate = mdc<MdcCheckbox>(ref).indeterminate;
    return (indeterminate) ? null : checked;
}

export function setValue(ref: Element, value: boolean | null): void {
    mdc<MdcCheckbox>(ref).checked = !!value;
    mdc<MdcCheckbox>(ref).indeterminate = (value == null);
}

export function getDisabled(ref: Element): boolean {
    return mdc<MdcCheckbox>(ref).disabled;
}

export function setDisabled(ref: Element, value: boolean): void {
    console.info(ref, "disable set to: ", value);
    mdc<MdcCheckbox>(ref).disabled = value;
}