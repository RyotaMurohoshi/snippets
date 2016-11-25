package com.muhron.kotlin_java_interpolator

fun main(args: Array<String>) {
    val s00 : String = Utility.returnStringNonNull()
    val s01 : String? = Utility.returnStringNonNull()
//    val s10 : String = Utility.returnStringNull()
    val s11 : String? = Utility.returnStringNull()

    val s20 : String = Utility.returnStringWithNotNullAnnotation()
    val s21 : String? = Utility.returnStringWithNotNullAnnotation()

//    val s30 : String = Utility.returnStringWithNullableAnnotation()
    val s31 : String? = Utility.returnStringWithNullableAnnotation()

    val s40 : String = returnString()
    val s41 : String? = returnString()

//    val s50 : String = returnStringNullableReturnNonNull()
    val s51 : String? = returnStringNullableReturnNonNull()

//    val s60 : String = returnStringNullableReturnNull()
    val s61 : String? = returnStringNullableReturnNull()
}


fun returnString() : String = ""
fun returnStringNullableReturnNonNull() : String? = ""
fun returnStringNullableReturnNull() : String? = null
