import { MDCCircularProgress } from '@material/circular-progress';
import { mdc, mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcCircularProgress extends MDCCircularProgress {
    constructor(ref: Element) {
        super(ref);
    }
}

export function init(ref: Element): void {
    mdcInit(ref, new MdcCircularProgress(ref));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}

export function setDeterminate(ref: Element, value: boolean): void {
    mdc<MdcCircularProgress>(ref).determinate = value;
}

export function setProgress(ref: Element, value: number): void {
    mdc<MdcCircularProgress>(ref).progress = value;
}

export function open(ref: Element): void {
    mdc<MdcCircularProgress>(ref).open();
}

export function close(ref: Element): void {
    mdc<MdcCircularProgress>(ref).close();
}