import { MDCList } from '@material/list';
import { mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

export function init(ref: Element): void {
    mdcInit(ref, new MDCList(ref));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}