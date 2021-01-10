import { MDCChipInteractionEvent, MDCChipNavigationEvent, MDCChipRemovalEvent, MDCChipSelectionEvent, MDCChipSet, MDCChipTrailingActionInteractionEvent } from '@material/chips';
import { mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

/*
    MDCChip:interaction	{chipId: string}	                                Indicates the chip was interacted with (via click/tap or Enter key)
    MDCChip:selection	{chipId: string, selected: boolean}                 Indicates the chip's selection state has changed (for choice/filter chips)
    MDCChip:removal	    {chipId: string, removedAnnouncement: string}
    MDCChip:trailingIconInteraction	{chipId: string}                        Indicates the chip's trailing icon was interacted with (via click/tap or Enter key)
    MDCChip:navigation	{chipId: string, key: string, source: FocusSource}	Indicates a navigation event has occurred on a chip
*/

class MdcChipSet extends MDCChipSet {
    constructor(ref: Element, component: DotNet.DotNetObject) {
        super(ref);

        this.listen("MDCChip:interaction", (args: MDCChipInteractionEvent) => {
            // console.log("MDCChip:interaction", args.detail);
        });
        this.listen("MDCChip:selection", (args: MDCChipSelectionEvent) => {
            console.log("MDCChip:selection", args.detail);
        });
        this.listen("MDCChip:removal", (event: MDCChipRemovalEvent) => {
            console.log("MDCChip:removal", event.detail);
        });
        this.listen("MDCChip:trailingIconInteraction", (args: MDCChipTrailingActionInteractionEvent) => {
            console.log("MDCChip:trailingIconInteraction", args.detail);
        });
        this.listen("MDCChip:navigation", (args: MDCChipNavigationEvent) => {
            console.log("MDCChip:navigation", args.detail);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcChipSet(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}