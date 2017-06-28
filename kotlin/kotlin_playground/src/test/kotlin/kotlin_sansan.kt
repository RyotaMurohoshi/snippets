package com.mrstar.kotlin_playground

import org.junit.Assert
import org.junit.Test

class KotlinSansanTest {

    @Test
    fun stringToNumberConversions() {
        Assert.assertEquals("1".toInt(), 1)

        try {
            "-".toInt()
            Assert.fail()
        } catch (e: NumberFormatException) {

        }

        Assert.assertEquals("1".toIntOrNull(), 1)
        Assert.assertEquals("-".toIntOrNull(), null)

        Assert.assertEquals("111".toIntOrNull(2), 7)
        Assert.assertEquals("2".toIntOrNull(2), null)
    }

    @Test
    fun onEachTest() {
        val unit: Unit = listOf(1, 2, 3)
                .map { it * it }
                .forEach { println(it) }

        val list: List<Int> = listOf(1, 2, 3)
                .map { it * it }
                .onEach { println(it) }

        val sequence: Sequence<Int> = sequenceOf(1, 2, 3)
                .onEach { println(it) }
                .map { it * it }
                .onEach { println(it) }

        for (e in sequence) {
            println("$e in for")
        }
    }


    @Test
    fun scopeTest() {
        val evenOrNull: Int? = 2.takeIf { it % 2 == 0 }
        Assert.assertEquals(2, evenOrNull)

        val oddOrNull: Int? = 2.takeUnless { it % 2 == 0 }
        Assert.assertEquals(null, oddOrNull)
    }

    @Test
    fun toMapTest() {
        val original = mutableMapOf(1 to "A", 2 to "B")
        val copied = original.toMap()
        original[3] = "C"
        Assert.assertEquals(3, original.size)
        Assert.assertEquals(2, copied.size)
    }

    @Test
    fun mapMinusTest() {
        val map = mapOf(1 to "A", 2 to "B")
        val added = map + (3 to "C")
        val minused = map - 1
    }

    @Test
    fun minOfMaxOfTest() {

        val list: AbstractList<Int>? = null

        val min: Int = minOf(1, 2, 3)


        val arrayList: ArrayList<Int>? = null
    }

    @Test
    fun mapGetDefaultTest() {
        val map: Map<Int, String> = mapOf(1 to "A", 2 to "B")
        val value: String = map.getValue(0)
        val valueOrNull: String? = map[0]
    }

    @Test
    fun listFuncTest() {

        val array = Array(10) { 0 }

        val actual = List(size = 4) { it * it }
        val expected = listOf(0, 1, 4, 9)

        Assert.assertEquals(expected, actual)
    }

    @Test
    fun arrayTest() {
        println(arrayOf(1, 2, 3).toString())
        println(arrayOf(1, 2, 3).contentToString())

        println(arrayOf(1, 2, 3).equals(arrayOf(1, 2, 3)))
        println(arrayOf(1, 2, 3).contentEquals(arrayOf(1, 2, 3)))

    }
}