import { MDCSelectIcon } from '@material/select/icon';
import { mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

export function init(ref: Element): void {
    mdcInit(ref, new MDCSelectIcon(ref));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}