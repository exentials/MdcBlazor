import { strings, MDCDialog, MDCDialogCloseEvent } from '@material/dialog';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcDialog extends MDCDialog {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);

        this.listen(strings.OPENING_EVENT, () => {
            this.component.invokeMethodAsync(strings.OPENING_EVENT);
        });
        this.listen(strings.OPENED_EVENT, () => {
            this.component.invokeMethodAsync(strings.OPENED_EVENT);
        });
        this.listen(strings.CLOSING_EVENT, (event: MDCDialogCloseEvent) => {
            this.component.invokeMethodAsync(strings.CLOSING_EVENT, event.detail.action);
        });
        this.listen(strings.CLOSED_EVENT, (event: MDCDialogCloseEvent) => {
            this.component.invokeMethodAsync(strings.CLOSED_EVENT, event.detail.action);
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