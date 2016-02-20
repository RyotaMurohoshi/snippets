'use strict'
var Ix = require('ix');

var source = Ix.Enumerable.range(0, 10);

console.log(source
    .bufferWithCount(3)
    .map(it => it.toArray())
    .toArray());

console.log(source
    .bufferWithCount(3, 3)
    .map(it => it.toArray())
    .toArray());

console.log(source
    .bufferWithCount(3, 4)
    .map(it => it.toArray())
    .toArray());

console.log(source
    .bufferWithCount(3, 2)
    .map(it => it.toArray())
    .toArray());

console.log(source
    .bufferWithCount(3, 2)
    .toArray());

console.log(source);
