import { MDCMenu, Corner, MDCMenuFoundation } from '@material/menu';
import { MDCMenuSurfaceFoundation } from '@material/menu-surface/foundation';
import { MDCMenuItemComponentEvent } from '@material/menu/types';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcMenu extends MDCMenu {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen(MDCMenuSurfaceFoundation.strings.CLOSED_EVENT, (event) => {
            this.component.invokeMethodAsync(MDCMenuSurfaceFoundation.strings.CLOSED_EVENT);
        });
        this.listen(MDCMenuFoundation.strings.SELECTED_EVENT, (event: MDCMenuItemComponentEvent) => {
            this.component.invokeMethodAsync(MDCMenuFoundation.strings.SELECTED_EVENT, event.detail.index)
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

export function setAnchorCorner(ref: Element, value: Corner): void {
    mdc<MdcMenu>(ref).setAnchorCorner(value);
}

export function setFixedPosition(ref: Element, value:boolean): void {
    mdc<MdcMenu>(ref).setFixedPosition(value);
}

export function setAbsolutePosition(ref: Element, x: number, y: number): void {
    mdc<MdcMenu>(ref).setAbsolutePosition(x, y);
}