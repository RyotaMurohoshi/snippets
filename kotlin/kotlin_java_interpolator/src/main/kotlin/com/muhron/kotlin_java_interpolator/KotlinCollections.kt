@file:JvmName("KotlinCollections")

package com.muhron.kotlin_java_interpolator

fun getIterable(): Iterable<Int> = emptyList()
fun getMutableIterable(): MutableIterable<Int> = mutableListOf()

fun getIterator(): Iterator<Int> = emptyList<Int>().iterator()
fun getMutableIterator(): MutableIterator<Int> = arrayListOf<Int>().iterator()

fun getList(): List<Int> = emptyList()
fun getMutableList(): MutableList<Int> = mutableListOf()

fun getSet(): Set<Int> = emptySet()
fun getMutableSet(): MutableSet<Int> = mutableSetOf()

fun getMap(): Map<Int, Int> = emptyMap()
fun getMutableMap(): MutableMap<Int, Int> = mutableMapOf()

