import { MDCChip, MDCChipRemovalEvent } from '@material/chips';
import { mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcChip extends MDCChip {
    constructor(ref: Element, component: DotNet.DotNetObject) {
        super(ref);
        this.shouldRemoveOnTrailingIconClick = false; // Remove element from Blazor
    }    
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcChip(ref, component));    
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}