package com.muhron.kotlin_java_interpolator

fun main(args: Array<String>) {
    f10()
}

fun f10(): Unit {
    val str = Utility.returnStringJava()

    println(str?.length)

    println(str.length)

    val strNotNull: String = str
    val strNullable: String? = str
}

fun f11(): Unit {
    val str: String = Utility.returnStringJava()

    println(str.length)

    println(str?.length)
}

fun f12(): Unit {
    val str: String? = Utility.returnStringJava()

    println(str?.length)

    // println(str.length)は、コンパイルエラー
}
