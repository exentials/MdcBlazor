import { MDCDataTable } from '@material/data-table';
import { mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcDataTable extends MDCDataTable {
    constructor(ref: Element, component: DotNet.DotNetObject) {
        super(ref);
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcDataTable(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}