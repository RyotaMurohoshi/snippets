'use strict';

let Xray = require('x-ray');
let xray = Xray();
let url = 'http://qiita.com/RyotaMurohoshi/stock';
let selector = ['.tableList_item h1 a@href'];

xray(url, selector)((error, result) => console.log(result));
