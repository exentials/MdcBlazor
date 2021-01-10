import { MDCTabBar, MDCTabBarActivatedEvent } from '@material/tab-bar';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class TabBar extends MDCTabBar {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);

        this.listen("MDCTabBar:activated", (event: MDCTabBarActivatedEvent) => {
            this.component.invokeMethodAsync("ChangeTab", event.detail.index);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new TabBar(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function activateTab(ref: Element, index: number) {
    mdc<MDCTabBar>(ref).activateTab(index);
}