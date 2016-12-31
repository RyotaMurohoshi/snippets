'use strict'
var Xray = require('x-ray');
var Promise = require('bluebird');

var x = Xray();

function extract(userName) {
  var url = `https://github.com/users/${userName}/contributions`;
  return new Promise((resolve, reject) => {
    x(url, 'rect', [{ count: '@data-count', date: '@data-date' }])((error, result) => {
      if (error) {
        reject(error);
      } else {
        resolve(result);
      }
    });
  });
}

extract('RyotaMurohoshi').then(console.log);
