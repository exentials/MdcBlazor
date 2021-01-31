import { strings, MDCList, MDCListActionEvent } from "@material/list";
import { mdcDestroy, mdcInit, native_events } from "../mdc/mdcBlazor";

class MdcDrawerNav extends MDCList {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.wrapFocus = true;
        this.listen(native_events.CLICK, (event: MDCListActionEvent) => {
            this.component.invokeMethodAsync(strings.ACTION_EVENT, -1);
        });
        this.listen(strings.ACTION_EVENT, (event: MDCListActionEvent) => {
            this.component.invokeMethodAsync(strings.ACTION_EVENT, event.detail.index);
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