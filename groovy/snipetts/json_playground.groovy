import groovy.json.*

def jsonString = """{
  "name":"RyotaMurohoshi",
  "languages":["C#", "Java", "Kotlin", "Groovy"]
}"""

def json = new JsonSlurper().parseText(jsonString)
assert json.name == "RyotaMurohoshi"
assert json.languages == ["C#", "Java", "Kotlin", "Groovy"]

def map =  [
  name:"RyotaMurohoshi",
  "languages": ["C#", "Java", "Kotlin", "Groovy"]
]

assert new JsonBuilder(map).toString() == '{"name":"RyotaMurohoshi","languages":["C#","Java","Kotlin","Groovy"]}'
