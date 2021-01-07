import { MDCTooltip } from '@material/tooltip';
import { mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

export function init(ref: Element): void {
    mdcInit(ref, new MDCTooltip(ref));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}