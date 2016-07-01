package com.mrstar.kotlin_playground

import com.google.gson.Gson
import java.io.File

val gson = Gson()

fun sequenceExample2() {
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

fun listExample2() {
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

fun listExample0() {
    val list = listOf(1, 2, 3)
    val result = list.map {
        println("map $it")
        it
    }

    println("--------")

    for (it in result) println("for $it")

    /*
    map 1
    map 2
    map 3
    --------
    for 1
    for 2
    for 3
    */
}

fun listExample1() {
    val list = listOf(1, 2, 3, 4, 5, 6, 7, 8, 9)
    val result = list
            .map {
                println("map $it")
                it
            }
            .filter {
                println("filter $it")
                it % 2 == 0
            }
            .take(3)

    println("--------")

    for (it in result) println("for $it")

    /*
    map 1
    map 2
    map 3
    map 4
    map 5
    map 6
    map 7
    map 8
    map 9
    filter 1
    filter 2
    filter 3
    filter 4
    filter 5
    filter 6
    filter 7
    filter 8
    filter 9
    --------
    for 2
    for 4
    for 6
     */
}

fun sequenceExample0() {
    val list = listOf(1, 2, 3)
    val result = list
            .asSequence()
            .map {
                println("map $it")
                it
            }

    println("--------")

    for (it in result) println("for $it")

    /*
    --------
    map 1
    for 1
    map 2
    for 2
    map 3
    for 3
    */
}

fun sequenceExample1() {
    val list = sequenceOf(1, 2, 3, 4, 5, 6, 7, 8, 9)
    val result = list
            .map {
                println("map $it")
                it
            }
            .filter {
                println("filter $it")
                it % 2 == 0
            }
            .take(3)

    println("--------")

    for (it in result) println("for $it")

    /*
    --------
    map 1
    filter 1
    map 2
    filter 2
    for 2
    map 3
    filter 3
    map 4
    filter 4
    for 4
    map 5
    filter 5
    map 6
    filter 6
    for 6
    */
}


