'use strict';

let Xray = require('x-ray');
let xray = Xray();
let url = 'http://qiita.com/RyotaMurohoshi/items';
let selector = 'div.newUserPageProfile h3';

xray(url, selector)((error, result) => console.log(result));
