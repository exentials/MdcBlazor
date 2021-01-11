import { MDCTopAppBar } from '@material/top-app-bar';
import { dotnetInvokeMethodAsync, mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcTopAppBar extends MDCTopAppBar {

    constructor(ref: Element) {
        super(ref);
        this.listen("MDCTopAppBar:nav", this.navHandler);
    }

    async navHandler() {
        await dotnetInvokeMethodAsync("MDCTopAppBarNavHandler");
    }

    destroy() {
        this.unlisten("MDCTopAppBar:nav", this.navHandler);
        super.destroy()
    }
}

export function init(ref: Element) {
    mdcInit(ref, new MdcTopAppBar(ref));
}

export function destroy(ref: Element) {
    mdcDestroy(ref);
}

export function setScrollTarget(ref: Element, element: Element) {
    mdc<MdcTopAppBar>(ref).setScrollTarget(element);
}