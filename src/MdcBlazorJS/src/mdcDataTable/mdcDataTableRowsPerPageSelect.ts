import { strings, MDCSelect, MDCSelectEvent } from '@material/select';
import { mdcDestroy, mdcInit } from '../mdc/mdcBlazor';

class MdcDataTableRowsPerPageSelect extends MDCSelect {
    constructor(ref: Element, private component: DotNet.DotNetObject) {
        super(ref);
        this.listen(strings.CHANGE_EVENT, (event: MDCSelectEvent) => {
            this.component.invokeMethodAsync(strings.CHANGE_EVENT, event.detail.value);
        });
    }
}

export function init(ref: Element, component: DotNet.DotNetObject): void {
    mdcInit(ref, new MdcDataTableRowsPerPageSelect(ref, component));
}

export function destroy(ref: Element): void {
    mdcDestroy(ref);
}