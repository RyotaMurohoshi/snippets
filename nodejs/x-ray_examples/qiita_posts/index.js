'use strict';

var Xray = require('x-ray');
var x = Xray();

x(
  'http://qiita.com/RyotaMurohoshi',
  'article',
  [{
    title: 'div > div.ItemLink__title > a',
    link: 'div > div.ItemLink__title > a@href',
    at: 'div > div.ItemLink__info',
  }])((error, result) => {
    result.map(it => convertQiita(it)).forEach((it)=>console.log(it))
  })

x(
  'http://mrstar-logs.hatenablog.com/archive/2017',
  'section',
  [{ at: 'div.date > a > time',
     link: 'h1 > a@href',
     title: 'h1 > a'
  }]
 )((error, result) => {
   result.map(it => convertHatena(it)).forEach((it)=>console.log(it))
  })

function convertHatena(data) {
  let matched = data["at"].match(/\d{4}-(\d{2})-(\d{2})/)
  return `* [${data.title} (${matched[1]}/${matched[2]})](${data.link})`
}

function convertQiita(data) {
  let matched = data["at"].match(/\d{4}\/(\d{2})\/(\d{2})/)
  return `* [${data.title} (${matched[1]}/${matched[2]})](${data.link})`
}
