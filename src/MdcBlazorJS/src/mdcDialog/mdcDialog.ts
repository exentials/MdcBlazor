import { MDCDialog, MDCDialogCloseEvent } from '@material/dialog';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcDialog extends MDCDialog {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);

        this.listen("MDCDialog:opening", () => {
            this.component.invokeMethodAsync("MDCDialog:opening");
        });
        this.listen("MDCDialog:opened", () => {
            this.component.invokeMethodAsync("MDCDialog:opened");
        });
        this.listen("MDCDialog:closing", (event: MDCDialogCloseEvent) => {
            this.component.invokeMethodAsync("MDCDialog:closing", event.detail.action);
        });
        this.listen("MDCDialog:closed", (event: MDCDialogCloseEvent) => {
            this.component.invokeMethodAsync("MDCDialog:closed", event.detail.action);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcDialog(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getOpen(ref: Element) {
    return mdc<MdcDialog>(ref).isOpen;
}

export function setOpen(ref: Element, value: boolean) {
    if (value) {
        mdc<MdcDialog>(ref).open();
    }
    else {
        mdc<MdcDialog>(ref).close();
    }
}