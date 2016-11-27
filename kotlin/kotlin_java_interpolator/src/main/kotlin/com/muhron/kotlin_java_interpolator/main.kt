package com.muhron.kotlin_java_interpolator

fun main(args: Array<String>) {
    val s00: String = Utility.returnStringNonNull()
    val s01: String? = Utility.returnStringNonNull()
//    val s10 : String = Utility.returnStringNull()
    val s11: String? = Utility.returnStringNull()

    val s2 = Utility.returnStringWithNotNullAnnotation()
    val s20: String = Utility.returnStringWithNotNullAnnotation()
    val s21: String? = Utility.returnStringWithNotNullAnnotation()

//    val s30 : String = Utility.returnStringWithNullableAnnotation()
    val s31: String? = Utility.returnStringWithNullableAnnotation()

    val s40: String = returnString()
    val s41: String? = returnString()

//    val s50 : String = returnStringNullableReturnNonNull()
    val s51: String? = returnStringNullableReturnNonNull()

//    val s60 : String = returnStringNullableReturnNull()
    val s61: String? = returnStringNullableReturnNull()

    val l = Utility.returnStringList()
    println(l)
    val l1: List<String> = Utility.returnStringList()
    println(l1)
    val l2: MutableList<String> = Utility.returnStringList()
    println(l2)
    val l3: java.util.List<String> = Utility.returnStringList() as java.util.List<String>
    println(l3)

    val a: java.util.ArrayList<Int> = arrayListOf(1, 2, 3)
//    val list: java.util.List<Int> = a
    val list: kotlin.collections.List<Int> = a
}

fun returnString(): String = ""
fun returnStringNullableReturnNonNull(): String? = ""
fun returnStringNullableReturnNull(): String? = null
