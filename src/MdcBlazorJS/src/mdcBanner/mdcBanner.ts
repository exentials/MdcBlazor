import { events, CloseReason, MDCBanner, MDCBannerCloseEventDetail } from "@material/banner";
import { mdc, mdcDestroy, mdcInit } from "../mdc/mdcBlazor";

class MdcBanner extends MDCBanner {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen(events.CLOSING, () => {
            this.component.invokeMethodAsync(events.CLOSING);
        });
        this.listen(events.CLOSED, () => {
            this.component.invokeMethodAsync(events.CLOSED);
        });
        this.listen(events.OPENING, () => {
            this.component.invokeMethodAsync(events.OPENING);
        });
        this.listen(events.OPENED, () => {
            this.component.invokeMethodAsync(events.OPENED);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcBanner(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function open(ref: Element): void {
    mdc<MdcBanner>(ref).open();
}

export function close(ref: Element, reason: CloseReason): void {
    mdc<MdcBanner>(ref).close(reason);
}

export function isOpen(ref: Element): boolean {
    return mdc<MdcBanner>(ref).isOpen;
}

export function getText(ref: Element): string {
    return mdc<MdcBanner>(ref).getText();
}

export function setText(ref: Element, text: string): void {
    mdc<MdcBanner>(ref).setText(text);
}

export function getPrimaryActionText(ref: Element): string {
    return mdc<MdcBanner>(ref).getPrimaryActionText();
}

export function setPrimaryActionText(ref: Element, actionButtonText: string): void {
    mdc<MdcBanner>(ref).setPrimaryActionText(actionButtonText);
}