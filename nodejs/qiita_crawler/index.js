var Xray = require('x-ray');

var url = "http://qiita.com/RyotaMurohoshi/items";
var x = Xray();

x(url,
    ".tableList article",
    [{
        title: 'h1 a',
        url: 'h1 a@href',
        stockCount: '.publicItem_stockCount',
        commentsCount: '.publicItem_commentsCount',
        tags: [".tagList_item"]
    }])
    .paginate('ul.pagination a.js-next-page-link@href')
    .write('results.json');
