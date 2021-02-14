import { MDCSegmentedButtonEvent, MDCSegmentedButton, SegmentDetail } from '@material/segmented-button';
import { events } from '@material/segmented-button/segmented-button/constants';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcSegmentedButton extends MDCSegmentedButton {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen(events.CHANGE, (event: MDCSegmentedButtonEvent) => {
            this.component.invokeMethodAsync("MDCSegmentedButton:change", event.detail)
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcSegmentedButton(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function getSelectedSegments(ref: Element): readonly SegmentDetail[]  {
    return mdc<MdcSegmentedButton>(ref).getSelectedSegments();
}

export function selectSegment(ref: Element, indexOrSegmentId: number | string): void {
    mdc<MdcSegmentedButton>(ref).selectSegment(indexOrSegmentId);
}

export function unselectSegment(ref: Element, indexOrSegmentId: number | string): void {
    mdc<MdcSegmentedButton>(ref).unselectSegment(indexOrSegmentId);
}

export function isSegmentSelected(ref: Element, indexOrSegmentId: number | string): boolean {
    return mdc<MdcSegmentedButton>(ref).isSegmentSelected(indexOrSegmentId);
}