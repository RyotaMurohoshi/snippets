package com.mrstar.kotlin_playground

fun main(args: Array<String>) {

    example01()
}

fun example01(){
    println("---create list---")
    val list = listOf(1, 2, 3, 4, 5).map {
        println("list map $it")
        it
    }

    println("---loop list---")
    for(element in list){
        println("for print list loop : $element")
    }

    println("---create sequence---")
    val sequence = sequenceOf(1, 2, 3, 4, 5).map {
        println("sequence map $it")
        it
    }

    println("---loop sequence---")
    for(element in sequence){
        println("for print sequence loop : $element")
    }

/*
---create list---
list map 1
list map 2
list map 3
list map 4
list map 5
---loop list---
for print list loop : 1
for print list loop : 2
for print list loop : 3
for print list loop : 4
for print list loop : 5
---create sequence---
---loop sequence---
sequence map 1
for print sequence loop : 1
sequence map 2
for print sequence loop : 2
sequence map 3
for print sequence loop : 3
sequence map 4
for print sequence loop : 4
sequence map 5
for print sequence loop : 5
*/
}

