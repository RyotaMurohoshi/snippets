data class Person(val firstName: String, val lastName: String, val age: Int)

fun main(args: Array<String>) {
    val persons = listOf(
            Person(firstName = "Taro", lastName = "Sato", age = 25),
            Person(firstName = "Jiro", lastName = "Suzuki", age = 27),
            Person(firstName = "Taro", lastName = "Yamada", age = 25)
    )

    val personsWithObjectExpressions = persons
            .map{ object { val name = "${it.firstName} ${it.lastName}"; val age = it.age; }}
            .sortedBy { it.age }
    // not readable string.
    println(personsWithObjectExpressions);

    val personsWithPair = persons
            .map{ Pair("${it.firstName} ${it.lastName}", it.age)}
            .sortedBy { it.second }
    // readable string.
    println(personsWithPair);


//  next code is compile error.
//    val person = data object {
//        val name = "RyotaMurohoshi";
//        val age = 27;
//    }
}
