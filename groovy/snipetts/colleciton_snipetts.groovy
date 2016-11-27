// 射影
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].collect { it.length() } == [4, 6, 6, 5, 6]

// 選択
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].findAll { it.contains("#") } == ["C#", "F#"]

// 条件を満たす要素が存在するか
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].any { it.contains("#") } == true
assert [].any { it.contains("#") } == false

// すべての要素が条件を満たすか
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].every { it.contains("#") } == false
assert [].every { it.contains("#") } == true

// 条件を満たす要素を数え上げ
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].count { it.contains("#") } == 2

// ソート
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].sort() == ["Ceylon", "Groovy", "Java", "Kotlin", "Scala"]
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].sort { it.length() } == ["Java", "Scala", "Groovy", "Kotlin", "Ceylon"]

// 順番反転
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].reverse() == ["Ceylon", "Scala", "Kotlin", "Groovy", "Java"]

// 条件を満たす1要素取得
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].find { it.contains("#") } == null
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].find { it.contains("#") } == "C#"

// 条件を満たす1要素取得+変換
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].findResult { it.contains("#") ? "${it} has #." : null } == null
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].findResult { it.contains("#") ? "${it} has #." : null } == "C# has #."

// インデックス(添え字)との合成
assert ["Android", "iOS", "WindowsPhone"].withIndex() == [["Android", 0], ["iOS", 1], ["WindowsPhone", 2]]

// デフォルト値つき条件を満たす1要素取得+変換
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].findResult("No Result") { it.contains("#") ? "${it} has #." : null } == "No Result"
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].findResult("No Result") { it.contains("#") ? "${it} has #." : null } == "C# has #."

// http://docs.groovy-lang.org/latest/html/groovy-jdk/java/lang/Object.html
// http://docs.groovy-lang.org/latest/html/groovy-jdk/java/lang/Object[].html
// http://docs.groovy-lang.org/latest/html/groovy-jdk/java/util/Iterator.html#every


