import { MDCTopAppBar } from '@material/top-app-bar';
import { dotnetInvokeMethodAsync, mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcTopAppBar extends MDCTopAppBar {

    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);        
        this.listen("MDCTopAppBar:nav", (event) => {
            console.log("MDCTopAppBar:nav", event);
            this.component.invokeMethodAsync("MDCTopAppBar:nav");
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject) {
    mdcInit(ref, new MdcTopAppBar(ref, component));
}

export function destroy(ref: Element) {
    mdcDestroy(ref);
}

export function setScrollTarget(ref: Element, element: Element) {
    mdc<MdcTopAppBar>(ref).setScrollTarget(element);
}