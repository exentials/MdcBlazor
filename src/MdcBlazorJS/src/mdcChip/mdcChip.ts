import { chipStrings, MDCChip, MDCChipInteractionEvent, MDCChipNavigationEvent, MDCChipRemovalEvent, MDCChipSelectionEvent, MDCChipTrailingActionInteractionEvent } from '@material/chips';
import { mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcChip extends MDCChip {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.shouldRemoveOnTrailingIconClick = false; // Remove element from Blazor

        this.listen(chipStrings.INTERACTION_EVENT, (event: MDCChipInteractionEvent) => {
            this.component.invokeMethodAsync(chipStrings.INTERACTION_EVENT, event.detail.chipId);
        });
        this.listen(chipStrings.SELECTION_EVENT, (event: MDCChipSelectionEvent) => {
            this.component.invokeMethodAsync(chipStrings.SELECTION_EVENT, event.detail.chipId, event.detail.selected);
        });
        this.listen(chipStrings.REMOVAL_EVENT, (event: MDCChipRemovalEvent) => {
            this.component.invokeMethodAsync(chipStrings.REMOVAL_EVENT, event.detail.chipId, event.detail.removedAnnouncement);
        });
        this.listen(chipStrings.TRAILING_ICON_INTERACTION_EVENT, (event: MDCChipTrailingActionInteractionEvent) => {
            this.component.invokeMethodAsync(chipStrings.TRAILING_ICON_INTERACTION_EVENT, event.detail.trigger);
        });
        this.listen(chipStrings.NAVIGATION_EVENT, (event: MDCChipNavigationEvent) => {
            this.component.invokeMethodAsync(chipStrings.NAVIGATION_EVENT, event.detail.chipId, event.detail.key);
        });
    }    
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcChip(ref, component));    
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}