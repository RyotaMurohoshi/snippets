'use strict'
var Ix = require('ix');

var source = Ix.Enumerable.range(0, 10);

console.log(source
    .where(it => it % 2 != 0)
    .select(it => it * 2)
    .toArray());

console.log(source
    .repeat()
    .take(15)
    .toArray());

console.log(source
    .bufferWithCount(3)
    .map(it => it.toArray())
    .toArray());

console.log(source.aggregate((acc, elem) => acc + elem));
console.log(source.scan((acc, elem) => acc + elem).toArray());

console.log(source.count(it => it % 2 == 0));
console.log(Ix.Enumerable
    .fromArray(["JavaScript", "TypeScript", "CoffeScript", "Elm"])
    .maxBy(it => it.length)
    .toArray());
console.log(Ix.Enumerable
    .fromArray(["JavaScript", "TypeScript", "CoffeScript", "Elm"])
    .minBy(it => it.length)
    .toArray());
console.log(Ix.Enumerable
    .fromArray(["JavaScript", "TypeScript", "CoffeScript", "Elm"])
    .max(it => it.length));
console.log(Ix.Enumerable
    .fromArray(["JavaScript", "TypeScript", "CoffeScript", "Elm"])
    .min(it => it.length));

console.log(source
    .bufferWithCount(3, 2)
    .map(it => it.toArray())
    .toArray());

let dict = source.toDictionary(it => it, it => it * 10);
console.log(dict.tryGetValue(1));

let lookup = source.toLookup(it => it % 2);
console.log(lookup.get(0).toArray());
console.log(lookup.get(1).toArray());


console.log(source.takeLast(3).toArray());
console.log(source.skipLast(3).toArray());
