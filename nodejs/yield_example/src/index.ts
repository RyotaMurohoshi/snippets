'use strict';

function* to<T>(array: T[]): IterableIterator<T> {
    for (let t of array) {
        yield t;
    }
}

function* filter<TSource>(
    iterable: IterableIterator<TSource>,
    predicate: (t: TSource) => boolean): IterableIterator<TSource> {

    for (let t of iterable) {
        if (predicate(t)) {
            yield t;
        }
    }
}

function* map<TSource, TResult>(
    iterable: IterableIterator<TSource>,
    selector: (t: TSource) => TResult): IterableIterator<TResult> {

    for (let t of iterable) {
        yield selector(t);
    }
}

let i0 = to([1, 2, 3, 4, 5]);
let i1 = filter(i0, it => it % 2 == 0);
let i2 = map(i1, it => it * it);

for (let num of i2) {
    console.log(num);
}