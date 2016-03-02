@ToConstantString(defaultString = "This is Person")
class Person{
    String name;
    int age;
}

println(new Person(name:"Ryota", age:27).toString())
