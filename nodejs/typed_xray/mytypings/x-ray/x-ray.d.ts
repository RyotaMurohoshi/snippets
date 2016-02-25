interface XraySelector {
    (url: string, selector: string): XrayResult<string>;
    (url: string, scope: string, selector: string): XrayResult<string>;

    (url: string, selector: string[]): XrayResult<string[]>;
    (url: string, scope: string, selector: string[]): XrayResult<string[]>;

    <T>(url: string, selector: T): XrayResult<T>;
    <T>(url: string, scope: string, selector: T): XrayResult<T>;

    <T>(url: string, selector: [T]): XrayResult<[T]>;
    <T>(url: string, scope: string, selector: [T]): XrayResult<[T]>;
}

interface XrayAPI {
    (): XraySelector;
}

interface XrayConsume<T> {
    (error: Error, result: T): void
}

interface XrayResult<T> {
    (result: XrayConsume<T>): void
    limit(count: number): XrayResult<T>
    paginate(selector: string): XrayResult<T>
    write(fileName: string): void
}

declare module "x-ray" {
    export = x_ray

    var x_ray: XrayAPI;
}
