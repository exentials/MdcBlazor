import { MDCList, MDCListActionEvent } from "@material/list";
import { mdcDestroy, mdcInit } from "../mdc/mdcBlazor";

class MdcDrawerNav extends MDCList {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.wrapFocus = true;
        this.listen("click", (event: MDCListActionEvent) => {
            this.component.invokeMethodAsync("MDCList:action", -1);
        });
        this.listen("MDCList:action", (event: MDCListActionEvent) => {
            this.component.invokeMethodAsync("MDCList:action", event.detail.index);
        });

        this.listElements?.forEach((element, index) => {
            element.setAttribute("tabindex", index.toString());
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject) {
    mdcInit(ref, new MdcDrawerNav(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}