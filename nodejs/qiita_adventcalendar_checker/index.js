'use strict'
var Xray = require('x-ray');
var Promise = require("bluebird");
var _ = require('underscore');

var x = Xray();

function crawlTargetCalendar(calendarUrl) {
    return new Promise(function (resolve, reject) {
        x(calendarUrl, ".adventCalendarCalendar_day",
            [{
                day: ".adventCalendarCalendar_date",
                url: ".adventCalendarCalendar_comment a@href"
            }])
            (function (error, result) {
                if (error) {
                    reject(error);
                } else {
                    resolve(result);
                }
            });
    });
}

function convertStatistics(crawlingResult) {
    return {
        postedCount: _.filter(crawlingResult, isPosted).length,
        qiitaItemCount: _.filter(crawlingResult, isQiitaItem).length,
    };

    function isPosted(aDay) { return !!(aDay.url); }
    function isQiitaUrl(itemUrl) { return itemUrl.indexOf("http://qiita.com") == 0; }
    function isQiitaItem(aDay) { return isPosted(aDay) && isQiitaUrl(aDay.url); }
}

function crawlQiitaAllCalendars() {
    return new Promise(function (resolve, reject) {
        x("http://qiita.com/advent-calendar/2015/calendars", ".adventCalendarList tr",
            [{
                title: ".adventCalendarList_calendarTitle a",
                url: ".adventCalendarList_calendarTitle a@href",
            }])
            .paginate(".js-next-page-link@href")
            (function (error, result) {
                if (error) {
                    reject(error);
                } else {
                    resolve(result);
                }
            });
    });
}

function crawlCalendarFromBaseInfo(calendarBaseInfo) {
    return crawlTargetCalendar(calendarBaseInfo.url)
        .then(convertStatistics)
        .then(function (statistics) {
            statistics.title = calendarBaseInfo.title;
            statistics.url = calendarBaseInfo.url;
            return statistics;
        })
}

function crawlSequentially(baseInfoArray) {
    let tasks = baseInfoArray.map(convertToTask);
    return sequenceExece(tasks);

    function convertToTask(baseInfo) {
        return () => crawlCalendarFromBaseInfo(baseInfo);
    }
}

function sequenceExece(tasks) {
    function recordValue(results, value) {
        results.push(value);
        return results;
    }
    let pushValue = recordValue.bind(null, []);
    let initValue = Promise.resolve();
    return tasks.reduce((promise, task) => promise.then(task).then(pushValue), initValue);
}

crawlQiitaAllCalendars()
    .then(crawlSequentially)
    .then(console.log)