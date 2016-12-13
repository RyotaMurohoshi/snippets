package com.muhron.kotlin_java_interpolator

fun main(args: Array<String>) {

    // kotlin.Int
    val num0 = JInts.getPrimitiveInt()

    // kotlin.Int!(Platform Type)
    val num1 = JInts.getWrapperInteger()

    // kotlin.Int?
    val num2 = JInts.getWrapperIntegerNullable()

    // kotlin.Int
    val num3 = JInts.getWrapperIntegerNotNull()
}
