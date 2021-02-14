import { MDCLinearProgress } from '@material/linear-progress';

import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcLinearProgress extends MDCLinearProgress {
    constructor(ref: Element) {
        super(ref);
    }
}

export function init(ref: Element): void {
    mdcInit(ref, new MdcLinearProgress(ref));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function setDeterminate(ref: Element, value: boolean): void {
    mdc<MdcLinearProgress>(ref).determinate = value;
}

export function setProgress(ref: Element, value: number): void {
    mdc<MdcLinearProgress>(ref).progress = value;
}

export function setBuffer(ref: Element, value: number): void {
    mdc<MdcLinearProgress>(ref).buffer = value;
}

export function open(ref: Element): void {
    mdc<MdcLinearProgress>(ref).open();
}

export function close(ref: Element): void {
    mdc<MdcLinearProgress>(ref).close();
}