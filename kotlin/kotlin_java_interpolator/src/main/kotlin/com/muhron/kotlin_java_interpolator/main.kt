package com.muhron.kotlin_java_interpolator

fun main(args: Array<String>) {
    useNullableFunJavaAsString()
}

fun examples(): Unit {
    val s00: String = Utility.returnStringNonNull()
    val s01: String? = Utility.returnStringNonNull()
//    val s10 : String = Utility.returnStringNull()
    val s11: String? = Utility.returnStringNull()

    val s2 = Utility.returnStringWithNotNullAnnotation()
    val s20: String = Utility.returnStringWithNotNullAnnotation()
    val s21: String? = Utility.returnStringWithNotNullAnnotation()

//    val s30 : String = Utility.returnStringWithNullableAnnotation()
    val s31: String? = Utility.returnStringWithNullableAnnotation()


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

fun useNullableFunKotlin(): Unit {
    val str = returnNullableStringKotlin()

    // これもOK
    // val str : String? = returnNullableStringKotlin()

    // これはコンパイルエラー
    // val str : String = returnNullableStringKotlin()

    // println(str.length) // コンパイルエラー

    println(str?.length) // これならOK
}

fun useNullableFunJava(): Unit {
    val str = Utility.returnNullableStringJava()


    // これもOK
    // val str : String? = Utility.returnNullableStringJava()

    // これもOK
    // val str : String = Utility.returnNullableStringJava()

    println(str?.length) // これならOK
    println(str.length) // これもOK
}

fun useNullableFunJavaAsNullableString(): Unit {
    val str: String? = Utility.returnNullableStringJava()
    println(str?.length)

    // コンパイルエラー
    // println(str.length)
}


fun useNullableFunJavaAsString(): Unit {
    val str: String = Utility.returnNullableStringJava()
    println(str.length)

    // それ必要ないよって、警告が出る
    // println(str?.length)
}


fun returnStringKotlin(): String = ""
fun returnNullableStringKotlin(): String? = null
