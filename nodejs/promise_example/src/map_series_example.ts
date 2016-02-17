/// <reference path="../typings/tsd.d.ts" />

import Promise = require('bluebird');

function returnDelay(arg: { message: string, delayMilliSeconds: number }) {
    return new Promise<string>((resolve, reject) => {
        setTimeout(() => {
            resolve(arg.message);
        }, arg.delayMilliSeconds);
    });
}

let args = [
    { message: 'Hello', delayMilliSeconds: 1000 },
    { message: 'Bye', delayMilliSeconds: 3000 },
    { message: 'Good morning', delayMilliSeconds: 500 },
    { message: 'Good night', delayMilliSeconds: 2000 }
];

Promise.mapSeries(args, returnDelay).then(console.log);
