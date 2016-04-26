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
