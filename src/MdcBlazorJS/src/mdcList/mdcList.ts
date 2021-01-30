import { strings, MDCList, MDCListIndex } from '@material/list';
import { MDCListActionEvent } from '@material/list/types';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcList extends MDCList {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen(strings.ACTION_EVENT, (event: MDCListActionEvent) => {
            if (Array.isArray(this.selectedIndex)) {
                this.component.invokeMethodAsync(strings.ACTION_EVENT, this.selectedIndex);
            } else {
                this.component.invokeMethodAsync(strings.ACTION_EVENT, [this.selectedIndex]);
            }
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcList(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function setSingleSelection(ref: Element, value: boolean): void {
    mdc<MdcList>(ref).singleSelection = value;
}

export function getSelectedIndex(ref: Element): MDCListIndex {
    return mdc<MdcList>(ref).selectedIndex;
}

export function setSelectedIndex(ref: Element, value: MDCListIndex): void {
    mdc<MdcList>(ref).selectedIndex = value;
}