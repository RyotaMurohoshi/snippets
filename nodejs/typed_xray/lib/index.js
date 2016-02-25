'use strict';
var Xray = require('x-ray');
var xray = Xray();
function singleElement() {
    var url = 'http://qiita.com/RyotaMurohoshi/items';
    var selector = 'div.newUserPageProfile h3';
    xray(url, selector)(function (error, result) {
        console.log(result);
    });
}
singleElement();
function arrayElements() {
    var url = 'http://qiita.com/RyotaMurohoshi/stock';
    var selector = ['.tableList_item h1 a@href'];
    xray(url, selector)(function (error, result) {
        console.log(result);
    });
}
arrayElements();
function arrayObjects() {
    var url = 'http://qiita.com/RyotaMurohoshi/stock';
    var scope = '.tableList_item';
    var selector = [{
            title: 'h1 > a',
            url: 'h1 > a@href',
            author: '.publicItem_status > a',
            tags: ['.tagList_item']
        }];
    xray(url, scope, selector)(function (error, result) { return console.log(result); });
}
arrayObjects();
function paginateOutput() {
    var url = 'http://qiita.com/RyotaMurohoshi/stock';
    var scope = '.tableList_item';
    var selector = [{
            title: 'h1 > a',
            url: 'h1 > a@href',
            author: '.publicItem_status > a',
            tags: ['.tagList_item']
        }];
    xray(url, scope, selector)
        .paginate('a[rel="next"]@href')
        .limit(10)
        .write('result.json');
}
