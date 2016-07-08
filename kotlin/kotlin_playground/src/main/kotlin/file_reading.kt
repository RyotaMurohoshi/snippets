package com.mrstar.kotlin_playground

import com.google.gson.Gson
import java.io.File

val fileName = "data.jsonlines"

fun main(args: Array<String>) {
    println("----------------------------")
    readLinesBad0()
    println("----------------------------")
    readLinesBad1()
    println("----------------------------")
    readLinesGood0()
    println("----------------------------")
    readLinesGood1()
    println("----------------------------")
}

fun readLinesGood1() {
    // Good 1
    // use use method to close handler

    val result: List<PersonData> = File(fileName)
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

    val result: List<PersonData> = File(fileName)
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
    val lineSequence = File(fileName)
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
    val lineList: List<String> = File(fileName).readLines()

    val result = lineList
            .map { convertToData(it) }
            .filter { filterData(it) }
            .take(10)

    for (it in result) {
        println(it)
    }
}

fun convertToData(string: String): PersonData = Gson().fromJson(string, PersonData::class.java)
fun filterData(person: PersonData): Boolean = 27 <= person.age && person.age < 33

data class PersonData(val name: String, val age: Int)
