import { MDCSnackbar } from '@material/snackbar';

import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcSnackbar extends MDCSnackbar {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcSnackbar(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function open(ref: Element): void {
    mdc<MdcSnackbar>(ref).open();
}

export function close(ref: Element, reason?: string): void {
    mdc<MdcSnackbar>(ref).close(reason);
}

export function timeoutMs(ref: Element, value: number): void {
    mdc<MdcSnackbar>(ref).timeoutMs = value;
}

