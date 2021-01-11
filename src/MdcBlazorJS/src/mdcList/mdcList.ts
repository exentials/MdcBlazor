import { MDCList } from '@material/list';
import { mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcList extends MDCList {
    constructor(ref: Element) {
        super(ref);
    }
}

export function init(ref: Element): void {
    mdcInit(ref, new MdcList(ref));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}