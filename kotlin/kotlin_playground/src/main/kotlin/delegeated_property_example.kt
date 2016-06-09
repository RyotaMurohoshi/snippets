package com.mrstar.kotlin_playground;

import kotlin.properties.ReadWriteProperty
import kotlin.reflect.KProperty

// Thanks https://t.co/2vYQDlBfBu
class IntRestrictedProperty(minValue:Int, maxValue:Int, initValue:Int = 0) : ReadWriteProperty<Any?, Int> {
    val valueRange = IntRange(minValue, maxValue)
    var currentValue = valueRange.clamp(initValue)

    override fun getValue(thisRef: Any?, prop: KProperty<*>): Int = currentValue

    override fun setValue(thisRef: Any?, prop: KProperty<*>, value: Int) {
        currentValue = valueRange.clamp(value)
    }

    fun IntRange.clamp (value:Int) : Int =
            when(true) {
                contains(value) -> value
                value < start -> start
                else -> endInclusive
            }
}

class ExamResult(val subject:String) {
    var point: Int by IntRestrictedProperty(minValue = 0, maxValue = 100)

    override fun toString(): String = "${subject} : ${point}"
}

fun main(args: Array<String>) {
    val japanese = ExamResult("国語")
    japanese.point = -10
    println(japanese) // 国語 : 0

    val english = ExamResult("英語")
    english.point = 110
    println(english) // 英語 : 100
}