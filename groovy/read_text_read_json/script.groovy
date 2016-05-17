import groovy.json.*

def slurper = new JsonSlurper()

new File('persons.jl')
  .readLines()
  .collect{ slurper.parseText(it) }
  .forEach{
    println "${it.name} ${it.age} ${it.sex}"
  }
