import { strings, MDCMenu } from '@material/menu';
import { MDCMenuItemComponentEvent } from '@material/menu/types';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcMenu extends MDCMenu {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen("close", (event) => {
            console.log("Close:", event);
        });
        this.listen(strings.SELECTED_EVENT, (event: MDCMenuItemComponentEvent) => {
            this.component.invokeMethodAsync(strings.SELECTED_EVENT, event.detail.index)
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcMenu(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getOpen(ref: Element): boolean {
    return mdc<MdcMenu>(ref).open;
}

export function setOpen(ref: Element, value: boolean): void {
    mdc<MdcMenu>(ref).open = value;
}

export function setFixedPosition(ref: Element, value:boolean): void {
    mdc<MdcMenu>(ref).setFixedPosition(value);
}

export function setAbsolutePosition(ref: Element, x: number, y: number): void {
    mdc<MdcMenu>(ref).setAbsolutePosition(x, y);
}