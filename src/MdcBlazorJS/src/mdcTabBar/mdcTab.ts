import { MDCTab } from "@material/tab/component";
import { mdcDestroy, mdcInit } from "../mdc/mdcBlazor";

export function init(ref: Element): void {
    mdcInit(ref, new MDCTab(ref));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}