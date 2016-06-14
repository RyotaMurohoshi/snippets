package com.mrstar.kotlin_playground

import java.time.ZonedDateTime

fun main(args: Array<String>) {
    println(ZonedDateTime.parse("2011-11-15T00:10:00+09:00").toDate())
}

fun ZonedDateTime.toDate() = let {
    it
        .minusHours(it.hour.toLong())
        .minusMinutes(it.minute.toLong())
        .minusSeconds(it.second.toLong())
}