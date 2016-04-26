assert [] == [].withIndex()
assert [["A", 0]] == ["A"].withIndex()
assert [["A", 0], ["B", 1]] == ["A", "B"].withIndex()
assert [["A", 0], ["B", 1], ["C", 2]] == ["A", "B", "C"].withIndex()
assert ["A", "C", "E"] == ["A", "B", "C", "D", "E", "F"].withIndex().findAll{ e, i -> i % 2 == 0 }.collect { e , i ->  e}
