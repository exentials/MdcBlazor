import { MDCList, MDCListIndex } from '@material/list';
import { MDCListActionEvent } from '@material/list/types';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcList extends MDCList {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen("MDCList:action", (event: MDCListActionEvent) => {            
            if (Array.isArray(this.selectedIndex)) {                
                this.component.invokeMethodAsync("MDCList:action", this.selectedIndex);
            } else {
                this.component.invokeMethodAsync("MDCList:action", [this.selectedIndex]);
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

export function setSingleSelection(ref: Element, value: boolean) {
    mdc<MdcList>(ref).singleSelection = value;
}

export function getSelectedindex(ref: Element): MDCListIndex {
    return mdc<MdcList>(ref).selectedIndex;
}

export function setSelectedIndex(ref: Element, value: MDCListIndex): void {
    mdc<MdcList>(ref).selectedIndex = value;
}