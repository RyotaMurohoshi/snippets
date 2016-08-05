def regexPattern00 = ~'hello'
assert 'java.util.regex.Pattern' == regexPattern00.class.name
assert regexPattern00 instanceof java.util.regex.Pattern

def regexPattern01 = ~/hello/
assert 'java.util.regex.Pattern' == regexPattern01.class.name
assert regexPattern00 instanceof java.util.regex.Pattern

def regexPattern02 = ~'he..o'
assert regexPattern02.matcher("hello").matches()
assert !regexPattern02.matcher("hell0").matches()

assert regexPattern02.isCase('hello')
assert !regexPattern02.isCase('hello!')

assert 'Hi world' == ('Hello world' =~ /Hello/).replaceFirst('Hi')

def target = 'Hello Guest.'
assert 'Hi Guest!' == target.replaceAll(/Hello (.+)./, 'Hi $1!')
