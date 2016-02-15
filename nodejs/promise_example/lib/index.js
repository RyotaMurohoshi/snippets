'use strict';
var Promise = require('bluebird');
var fs = require('fs');
Promise.promisify(fs.readFile)('res/hello.txt').then(function (it) { return console.log(it.toString()); });
