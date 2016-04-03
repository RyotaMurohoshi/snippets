/// <reference path="../typings/tsd.d.ts" />

import Promise = require('bluebird');

function returnDelay(arg: { message: string, delayMilliSeconds: number }) {
  return new Promise<string>((resolve, reject) => {
    setTimeout(() => {
      resolve(arg.message);
    }, arg.delayMilliSeconds);
  });
}

function reject(messaeg: string) {
  return Promise.reject('reject!');
}


returnDelay({ message: 'Hello', delayMilliSeconds: 1000 })
  .then(message => reject(message))
  .then(result => console.log(result))
  .catch(error => console.log(error));
