import { MDCFormField } from '@material/form-field';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

export function init(ref: Element): void {
    mdcInit(ref, new MDCFormField(ref));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}