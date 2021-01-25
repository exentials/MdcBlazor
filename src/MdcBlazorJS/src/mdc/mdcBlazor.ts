import { MDCComponent } from "@material/base/component";

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
    ref.mdcComponent = mdcComponent; 
    return mdcComponent;
}

export function mdcDestroy(ref: Element) {
    ref.mdcComponent?.destroy();
    delete ref.mdcComponent;
}

export function mdc<T extends MDCComponent<any>>(ref: Element): T {
    const mdcComponent = <T>ref.mdcComponent
    return mdcComponent;
}

export function dotnetInvokeMethodAsync<T>(methodIdentifier: string, ...args: any[]): Promise<T> {
    return DotNet.invokeMethodAsync<T>(AssemblyName, methodIdentifier, args);
}

export const NATIVE_CLICK = "NativeClick";
export const NATIVE_CHANGE = "NativeChange";
export const NATIVE_INPUT = "NativeInput";