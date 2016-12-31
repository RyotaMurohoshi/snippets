'use strict';

let Xray = require('x-ray');
let xray = Xray();
let url = 'http://taiyoproject.com/post-384';
let scope = ".article > ul > li"
let selector = [{url : 'a@href', title : 'a@title'}]
xray(url, scope, selector)((error, result) => console.log(result.map(it => `* [${it.title}](${it.url})`).join('\n')));
