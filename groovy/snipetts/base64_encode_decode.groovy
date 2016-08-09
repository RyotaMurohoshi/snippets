
def encodeToBase64(def string) {
  string.bytes.encodeBase64().toString()
}

def decodeFromBase64(def string) {
  new String(string.decodeBase64())
}


def message = 'So groovy!'
def encoded = encodeToBase64(message)
assert 'U28gZ3Jvb3Z5IQ==' == encodeToBase64(message)
assert message == decodeFromBase64(encoded)
