showUUID()

def showUUID(){
    println(UUID.randomUUID().toString())
}

def showUUIDs(){
    100.times { showUUID() }
}

