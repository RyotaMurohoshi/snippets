package com.mrstar.kotlin_playground

import org.junit.Assert.*
import org.junit.Test

class WhenTest {
    @Test
    fun testBoolean() {
        fun whenExample(num: Int) = when {
            num < 0 -> "Minus"
            num == 0 -> "Zero"
            else -> "Plus"
        }

        assertEquals("Zero", whenExample(0))
        assertEquals("Minus", whenExample(-1))
        assertEquals("Plus", whenExample(+1))
    }

    @Test
    fun testSwitch() {
        fun whenExample(num: Int) = when (num) {
            1 -> "1st"
            2 -> "2nd"
            3 -> "3rd"
            4, 5, 6, 7, 7, 8, 9, 10 -> "${num}th"
            else -> ""
        }

        assertEquals("1st", whenExample(1))
        assertEquals("2nd", whenExample(2))
        assertEquals("3rd", whenExample(3))
        assertEquals("4th", whenExample(4))
        assertEquals("5th", whenExample(5))
        assertEquals("6th", whenExample(6))
        assertEquals("7th", whenExample(7))
        assertEquals("8th", whenExample(8))
        assertEquals("9th", whenExample(9))
        assertEquals("10th", whenExample(10))

        assertEquals("", whenExample(0))
        assertEquals("", whenExample(11))
    }

}
