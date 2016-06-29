@Grab(group='com.google.code.gson', module='gson', version='2.7')

import com.google.gson.Gson
import com.google.gson.annotations.SerializedName
import groovy.transform.Canonical

enum Rank{
  @SerializedName("1st") First,
  @SerializedName("2nd") Second,
  @SerializedName("3rd") Third,
  Others
}

@Canonical
class Person{
  String name
  Rank rank

  Person(String name, Rank rank){
    this.name = name
    this.rank = rank
  }
}

def gson = new Gson()
def originalPerson = new Person ("Ryota", Rank.First)

def personString = gson.toJson(originalPerson)
assert personString == '{"name":"Ryota","rank":"1st"}'

def decodedPerson = gson.fromJson(personString, Person.class)
assert originalPerson == decodedPerson

