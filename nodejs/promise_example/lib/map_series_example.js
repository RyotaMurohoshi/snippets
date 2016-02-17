var Promise = require('bluebird');
function returnDelay(arg) {
    return new Promise(function (resolve, reject) {
        setTimeout(function () {
            resolve(arg.message);
        }, arg.delayMilliSeconds);
    });
}
var args = [
    { message: 'Hello', delayMilliSeconds: 1000 },
    { message: 'Bye', delayMilliSeconds: 3000 },
    { message: 'Good morning', delayMilliSeconds: 500 },
    { message: 'Good night', delayMilliSeconds: 2000 }
];
Promise.mapSeries(args, returnDelay).then(console.log);
