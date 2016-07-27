def message = 'So groovy!'

String encoded = message.bytes.encodeBase64().toString()
assert 'U28gZ3Jvb3Z5IQ==' == encoded

byte[] decoded = encoded.decodeBase64()
assert message == new String(decoded)
