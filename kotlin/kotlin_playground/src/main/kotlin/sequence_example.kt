package com.mrstar.kotlin_playground

fun main(args: Array<String>) {
}

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


