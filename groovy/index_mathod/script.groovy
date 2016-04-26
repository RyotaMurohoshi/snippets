assert [] == [].withIndex()
assert [["A", 0]] == ["A"].withIndex()
assert [["A", 0], ["B", 1]] == ["A", "B"].withIndex()
assert [["A", 0], ["B", 1], ["C", 2]] == ["A", "B", "C"].withIndex()
assert ["A", "C", "E"] == ["A", "B", "C", "D", "E", "F"].withIndex().findAll{ e, i -> i % 2 == 0 }.collect { e , i ->  e}

assert [:] == [].indexed()
assert [0 : "A"] == ["A"].indexed()
assert [0 : "A", 1 : "B"] == ["A", "B"].indexed()
assert [0 : "A", 1 : "B", 2 : "C"] == ["A", "B", "C"].indexed()

assert ["A", "B", "C"].withIndex() == ["A", "B", "C"].indexed().collect {i, e -> [e, i]}
assert ["A", "B", "C"].indexed() == ["A", "B", "C"].withIndex().collectEntries {e, i -> [i, e]}

assert [] == [].withIndex(10)
assert [["A", 10]] == ["A"].withIndex(10)
assert [["A", 10], ["B", 11]] == ["A", "B"].withIndex(10)
assert [["A", 10], ["B", 11], ["C", 12]] == ["A", "B", "C"].withIndex(10)

assert [:] == [].indexed(10)
assert [10 : "A"] == ["A"].indexed(10)
assert [10 : "A", 11 : "B"] == ["A", "B"].indexed(10)
assert [10 : "A", 11 : "B", 12 : "C"] == ["A", "B", "C"].indexed(10)