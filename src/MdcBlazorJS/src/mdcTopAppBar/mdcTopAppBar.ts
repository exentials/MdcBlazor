import { strings, MDCTopAppBar } from '@material/top-app-bar';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcTopAppBar extends MDCTopAppBar {

    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen(strings.NAVIGATION_EVENT, (event) => {            
            this.component.invokeMethodAsync(strings.NAVIGATION_EVENT);
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