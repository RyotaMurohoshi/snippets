"use strict";
var Promise = require('bluebird');
function returnDelay(arg) {
    return new Promise(function (resolve, reject) {
        setTimeout(function () {
            resolve(arg.message);
        }, arg.delayMilliSeconds);
    });
}
function reject(messaeg) {
    return Promise.reject('reject!');
}
returnDelay({ message: 'Hello', delayMilliSeconds: 1000 })
    .then(function (message) { return reject(message); })
    .then(function (result) { return console.log(result); })
    .catch(function (error) { return console.log(error); });
