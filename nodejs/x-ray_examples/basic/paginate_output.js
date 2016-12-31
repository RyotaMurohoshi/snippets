'use strict';

let Xray = require('x-ray');
let xray = Xray();
let url = 'http://qiita.com/RyotaMurohoshi/stock';
let scope = '.tableList_item';
let selector = [{
    title: 'h1 > a',
    url: 'h1 > a@href',
    author: ".publicItem_status > a",
    tags: [".tagList_item"]
}];

xray(url, scope, selector)
    .paginate('a[rel="next"]@href') // paginate url selector
    .limit(10) // max paginate count
    .write('result.json'); // write json file name
