package com.mrstar.kotlin_playground

import com.google.gson.Gson
import com.mrstar.kotlin_playground.PersonData
import java.io.File

val gson = Gson()

fun readLinesGood1() {
    // Good 1
    // use use method to close handler

    val result: List<PersonData> = File("data.jsonlines")
            .useLines { lineSequences: Sequence<String> ->
                lineSequences
                        .map { convertToData(it) }
                        .filter { filterData(it) }
                        .take(10)
                        .toList()
            }

    for (it in result) {
        println(it)
    }
}

fun readLinesGood0() {
    // Good 0
    // use use method to close handler

    val result: List<PersonData> = File("data.jsonlines")
            .bufferedReader()
            .use { bufferedReader ->
                bufferedReader
                        .lineSequence()
                        .map { convertToData(it) }
                        .filter { filterData(it) }
                        .take(10)
                        .toList()
            }

    for (it in result) {
        println(it)
    }
}

fun readLinesBad1() {
    // Bad Example
    // Need to close file handler
    val lineSequence = File("data.jsonlines")
            .bufferedReader()
            .lineSequence()

    val result = lineSequence
            .map { convertToData(it) }
            .filter { filterData(it) }
            .take(10)

    for (it in result) {
        println(it)
    }
}

fun readLinesBad0() {
    // Bad Example
    // Read all Files
    val lineList: List<String> =
            File("data.jsonlines").readLines()

    val result = lineList
            .map { convertToData(it) }
            .filter { filterData(it) }
            .take(10)

    for (it in result) {
        println(it)
    }
}

fun convertToData(string: String): PersonData = gson.fromJson(string, PersonData::class.java)
fun filterData(person: PersonData): Boolean = 27 <= person.age && person.age < 33

data class PersonData(val name: String, val age: Int)
