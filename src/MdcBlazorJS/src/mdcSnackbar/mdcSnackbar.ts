import { strings, MDCSnackbar, MDCSnackbarCloseEvent } from '@material/snackbar';

import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

interface ISnackbarOptions {
    label: string;
    buttonLabel: string;
    dismissable: boolean;
    timeout: number;
}

class MdcSnackbar extends MDCSnackbar {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen(strings.CLOSED_EVENT, (event: MDCSnackbarCloseEvent) => {
            this.component.invokeMethodAsync<void>(strings.CLOSED_EVENT, event.detail.reason);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcSnackbar(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function open(ref: Element): boolean {
    mdc<MdcSnackbar>(ref).open();
    return mdc<MdcSnackbar>(ref).isOpen;
}

export function isOpen(ref: Element): boolean {
    return mdc<MdcSnackbar>(ref).isOpen;
}

export function close(ref: Element, reason?: string): void {
    mdc<MdcSnackbar>(ref).close(reason);
}

export function timeoutMs(ref: Element, value: number): void {
    mdc<MdcSnackbar>(ref).timeoutMs = value;
}