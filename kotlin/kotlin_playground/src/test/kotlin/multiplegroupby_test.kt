package com.mrstar.kotlin_playground

import org.junit.Assert.*
import org.junit.Test

class Test {
    @Test
    fun extensionMethodTest() {
        val list = listOf(14, 15, 17, 19, 20, 21, 22, 25, 26, 27, 29, 30, 32, 33, 35, 36)

        val selector = { age: Int ->
            if (age < 20) {
                listOf("10th")
            } else if (age < 27) {
                listOf("20th")
            } else if (age < 30) {
                listOf("20th", "ara30")
            } else if (age < 33) {
                listOf("30th", "ara30")
            } else { // age >= 33
                listOf("30th")
            }
        }

        val map = list.multiGroupBy(selector)

        assertEquals(map, mapOf(
                "10th" to listOf(14, 15, 17, 19),
                "20th" to listOf(20, 21, 22, 25, 26, 27, 29),
                "30th" to listOf(30, 32, 33, 35, 36),
                "ara30" to listOf(27, 29, 30, 32)
        ))
    }
}
