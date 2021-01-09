import { MDCChip } from '@material/chips';
import { mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MDCChip(ref));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}