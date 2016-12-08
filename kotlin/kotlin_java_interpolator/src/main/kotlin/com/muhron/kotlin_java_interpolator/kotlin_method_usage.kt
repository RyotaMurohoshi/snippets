package com.muhron.kotlin_java_interpolator

fun returnString(): String = ""

fun f00(): Unit {
    val str000 = returnString()
    println(str000.length)
    // 次は?.は必要ないという旨の警告がでる
    // println(str000?.length)

    val str001: String = returnString()
    println(str001.length)
    // 次は?.は必要ないという旨の警告がでる
    // println(str001?.length)

    // String?にStringを代入することもできる
    val str002: String? = returnString()
    println(str002?.length)
    // println(str002.length)は、コンパイルエラー
}

fun returnNullableString(): String? = null

fun f01(): Unit {
    val str010 = returnNullableString()
    println(str010?.length)
    // println(str010.length)は、コンパイルエラー

    // Type Mismatchでコンパイルエラー
    // val str011: String = returnNullableString()

    val str012: String? = returnNullableString()
    println(str012?.length)
// println(str010.length)は、コンパイルエラー
}
