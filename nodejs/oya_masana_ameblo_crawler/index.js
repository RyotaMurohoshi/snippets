var Xray = require('x-ray');

var url = "http://ameblo.jp/ske48official/theme-10093677864.html";
var x = Xray();

x(url,
    {
        title: '.skinArticleHeader h1>a',
        url: '.skinArticleHeader h1>a@href',
        articleTime: '.articleTime>time',
        imageUrls: x('.articleText', ["img@src"])
    })
    .paginate('.pagingArea>.pagingNext@href')
    .write('results.json');