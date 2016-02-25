/// <reference path='../typings/tsd.d.ts' />
/// <reference path='../mytypings/x-ray/x-ray.d.ts' />

'use strict';

let Xray: XrayAPI = require('x-ray');
let xray: XraySelector = Xray();

function singleElement(): void {
    let url = 'http://qiita.com/RyotaMurohoshi/items';
    let selector = 'div.newUserPageProfile h3';

    xray(url, selector)((error, result) => {
        console.log(result);
    });
}

singleElement();

function arrayElements(): void {
    let url = 'http://qiita.com/RyotaMurohoshi/stock';
    let selector = ['.tableList_item h1 a@href'];

    xray(url, selector)((error, result) => {
        console.log(result);
    });
}

arrayElements();

function arrayObjects() {
    let url = 'http://qiita.com/RyotaMurohoshi/stock';
    let scope = '.tableList_item';
    let selector = [{
        title: 'h1 > a',
        url: 'h1 > a@href',
        author: '.publicItem_status > a',
        tags: ['.tagList_item']
    }];

    xray(url, scope, selector)((error, result) => console.log(result));
}

arrayObjects();

function paginateOutput() {
    let url = 'http://qiita.com/RyotaMurohoshi/stock';
    let scope = '.tableList_item';
    let selector = [{
        title: 'h1 > a',
        url: 'h1 > a@href',
        author: '.publicItem_status > a',
        tags: ['.tagList_item']
    }];

    xray(url, scope, selector)
        .paginate('a[rel="next"]@href') // paginate url selector
        .limit(10) // max paginate count
        .write('result.json'); // write json file name
}
