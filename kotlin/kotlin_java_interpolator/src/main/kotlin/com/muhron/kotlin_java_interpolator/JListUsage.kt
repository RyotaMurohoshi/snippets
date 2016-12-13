package com.muhron.kotlin_java_interpolator


fun main(args: Array<String>) {
    // kotlin.collections.List<String!>
//    val list = JLists.getMutableList()

    // OK
    val list : List<String> = JLists.getMutableList()

    // コンパイルエラー
    // val list : MutableList<String> = JLists.getMutableList()

    println(list.count()) // OK
    //list.clear() // コンパイルエラー
}


