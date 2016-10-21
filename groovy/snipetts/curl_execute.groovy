def process = "curl http://www.groovy-lang.org/".execute()
process.waitFor()
println process.text