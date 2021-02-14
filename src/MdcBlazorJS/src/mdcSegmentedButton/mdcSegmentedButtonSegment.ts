import { MDCSegmentedButtonEvent, MDCSegmentedButtonSegment, MDCSegmentedButtonSegmentFoundation } from '@material/segmented-button';
import { events } from '@material/segmented-button/segment/constants';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcSegmentedButtonSegment extends MDCSegmentedButtonSegment {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen(events.SELECTED, (event: MDCSegmentedButtonEvent) => {
            this.component.invokeMethodAsync("MDCSegmentedButtonSegment:selected", event.detail);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcSegmentedButtonSegment(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function setIndex(ref: Element, index: number): void {
    mdc<MdcSegmentedButtonSegment>(ref).setIndex(index);
}

export function setIsSingleSelect(ref: Element, isSingleSelect: boolean): void {
    mdc<MdcSegmentedButtonSegment>(ref).setIsSingleSelect(isSingleSelect);
}

export function isSelected(ref: Element): boolean {
    return mdc<MdcSegmentedButtonSegment>(ref).isSelected();
}

export function setSelected(ref: Element): void {
    mdc<MdcSegmentedButtonSegment>(ref).setSelected();
}

export function setUnselected(ref: Element): void {
    mdc<MdcSegmentedButtonSegment>(ref).setUnselected();
}

export function getSegmentId(ref: Element): string {
    return mdc<MdcSegmentedButtonSegment>(ref).getSegmentId();
}