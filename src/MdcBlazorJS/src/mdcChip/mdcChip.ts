import { MDCChip, MDCChipInteractionEvent, MDCChipNavigationEvent, MDCChipRemovalEvent, MDCChipSelectionEvent, MDCChipTrailingActionInteractionEvent } from '@material/chips';
import { mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcChip extends MDCChip {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.shouldRemoveOnTrailingIconClick = false; // Remove element from Blazor

        this.listen("MDCChip:interaction", (event: MDCChipInteractionEvent) => {
            this.component.invokeMethodAsync("MDCChip:interaction", event.detail.chipId);
        });
        this.listen("MDCChip:selection", (event: MDCChipSelectionEvent) => {
            this.component.invokeMethodAsync("MDCChip:selection", event.detail.chipId, event.detail.selected);
        });
        this.listen("MDCChip:removal", (event: MDCChipRemovalEvent) => {
            event.cancelBubble = true;
            this.component.invokeMethodAsync("MDCChip:removal", event.detail.chipId, event.detail.removedAnnouncement);
        });
        this.listen("MDCChip:trailingIconInteraction", (event: MDCChipTrailingActionInteractionEvent) => {
            this.component.invokeMethodAsync("MDCChip:trailingIconInteraction", event.detail.trigger);
        });
        this.listen("MDCChip:navigation", (event: MDCChipNavigationEvent) => {
            this.component.invokeMethodAsync("MDCChip:navigation", event.detail.chipId, event.detail.key);
        });
    }    
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcChip(ref, component));    
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}