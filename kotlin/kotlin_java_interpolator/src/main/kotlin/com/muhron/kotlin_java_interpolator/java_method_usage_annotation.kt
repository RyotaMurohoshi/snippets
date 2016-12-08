package com.muhron.kotlin_java_interpolator

fun main(args: Array<String>) {
    f21()
}

fun f20(): Unit {
    // String?型と推論される
    val str = Utility.returnStringJavaNullableAnnotation()

    // String?と型を明示的に書いてもOK
    // val str : String?= Utility.returnStringJavaNullableAnnotation()

    // コンパイルエラーに Type Mismatch
    // val str: String = Utility.returnStringJavaNullableAnnotation()

    println(str?.length)

    // コンパイルエラー
    // println(str.length)
}

fun f21(): Unit {
    // String型と推論される
    val str = Utility.returnStringJavaNotNullAnnotation()

    // Stringと型を明示的に書いてもOK
    // val str : String= Utility.returnStringJavaNotNullAnnotation()

    // String?にも代入できる
    // val str: String? = Utility.returnStringJavaNotNullAnnotation()

    println(str.length)
    println(str?.length)
}
