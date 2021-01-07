import { MDCComponent } from "@material/base/component";

export const elements: Element[] = []; // TODO: Should remove, only for inspection on browser console during initial development

declare global {
    interface Element {
        mdcComponent: MDCComponent<any>;
    }

    interface IExentials {
        mdcBlazor?: any;
    }

    interface Window {
        exentials: IExentials;
    }
}

const AssemblyName = "Exentials.MdcBlazor";

export function mdcInit<T extends MDCComponent<any>>(ref: Element, mdcComponent: T): T {    
    ref.mdcComponent = mdcComponent; // TODO: Should remove
    elements.push(ref);
    return mdcComponent;
}

export function mdcDestroy(ref: Element) {
    const idx = elements.indexOf(ref); // TODO: Should remove
    if (idx > -1) elements.splice(idx); // TODO: Should remove
    ref.mdcComponent?.destroy();
    delete ref.mdcComponent;
}

export function mdc<T extends MDCComponent<any>>(ref: Element): T {
    return <T>ref.mdcComponent;
}

export function dotnetInvokeMethodAsync<T>(methodIdentifier: string, ...args: any[]): Promise<T> {
    return DotNet.invokeMethodAsync<T>(AssemblyName, methodIdentifier, args);
}