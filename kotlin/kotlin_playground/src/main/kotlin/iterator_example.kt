package com.mrstar.kotlin_playground;

fun main(args: Array<String>) {
//    This is compile error.
//    for (num in IteratorOperator(10)) {
//        println(num)
//    }

    for (num in IteratorImplementation(10)) {
        println(num)
    }

    for (num in CountLooperWithOperatorClass(10)) {
        println(num)
    }

    for (num in CountLooperWithIteratorClass(10)) {
        println(num)
    }

    val team = Team(listOf(
            Player("Taro"),
            Player("Jiro"),
            Player("Saburo")
    ))
    for (member in team){
        println(member)
    }
}

class IteratorImplementation(val count: Int) : kotlin.collections.Iterator<Int> {
    var currentCount = 0
    override operator fun hasNext(): Boolean = currentCount < count
    override operator fun next(): Int = currentCount++
}

class IteratorOperator(val count: Int) {
    var currentCount = 0
    operator fun hasNext(): Boolean = currentCount < count
    operator fun next(): Int = currentCount++
}

class CountLooperWithIteratorClass(val count: Int) {
    operator fun iterator() = IteratorImplementation(count)
}

class CountLooperWithOperatorClass(val count: Int) {
    operator fun iterator() = IteratorOperator(count)
}

data class Player(val name: String)
data class Team(val members: List<Player>)
operator fun Team.iterator() = members.iterator()