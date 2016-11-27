// 射影
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].collect { it.length() } == [4, 6, 6, 5, 6]

// 選択
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].findAll { it.contains("#") } == ["C#", "F#"]

// 条件を満たす要素が存在するか
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].any { it.contains("#") } == false
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].any { it.contains("#") } == true
assert [].any { it.contains("#") } == false

// すべての要素が条件を満たすか
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].every { it.length() > 3 } == true
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].every { it.length() > 3 } == false
assert [].every { it.contains("#") } == true

// 条件を満たす要素を数え上げ
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].count { it.contains("#") } == 2

// 条件を満たす1要素取得
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].find { it.contains("#") } == null
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].find { it.contains("#") } == "C#"

// ソート
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].sort() == ["Ceylon", "Groovy", "Java", "Kotlin", "Scala"]
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].sort { it.length() } == ["Java", "Scala", "Groovy", "Kotlin", "Ceylon"]

// 射影 + 平滑化
assert [
        ["runtime":".NET", "languages": ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"]],
        ["runtime":"JVM", "languages": ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"]]
    ].collectMany{ it["languages"] } ==
    ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo", "Java", "Groovy", "Kotlin", "Scala", "Ceylon"]

// グループ化
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].groupBy { it.contains("#") ? "has#" : "no#"} ==
    ["has#":["C#", "F#"], "no#":["VB", "IronPython", "IronRuby", "Boo"]]

// 平滑化
assert [["Java", "Groovy", "Kotlin", "Scala", "Ceylon"],  ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"]].flatten() ==
    ["Java", "Groovy", "Kotlin", "Scala", "Ceylon", "C#", "F#", "VB", "IronPython", "IronRuby", "Boo"]
assert [[1, 2],[[3, 4], [5,[6]]],[7],[8, 9, 0],[]].flatten() == [1, 2, 3, 4, 5, 6, 7, 8, 9, 0]

// 重複排除
assert [3, 1, 4, 1, 5, 9].toUnique() == [3, 1, 4, 5, 9]

// 重複排除（セットに変換）
assert [3, 1, 4, 1, 5, 9].toSet() == [3, 1, 4, 5, 9] as Set

// 和集合
assert [3, 1, 4, 1, 5, 9].toSet() + [1, 4, 1, 4, 2, 3].toSet() == [3, 1, 4, 1, 5, 9, 2].toSet()

// 共通集合
assert [3, 1, 4, 1, 5, 9].toSet().intersect([1, 4, 1, 4, 2, 3].toSet())  == [1, 4, 3].toSet()

// 差集合
assert [3, 1, 4, 1, 5, 9].toSet() - [1, 4, 1, 4, 2, 3].toSet()  == [5, 9].toSet()

// 順番反転
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].reverse() == ["Ceylon", "Scala", "Kotlin", "Groovy", "Java"]

// 指定要素が存在するか
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].contains("Groovy") == true
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].contains("Groovy") == false

// 先頭より指定要素数から新たなListを生成
assert  ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].take(2) == ["C#", "F#"]

// 末尾より指定要素数から新たなListを生成
assert  ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].takeRight(2) == ["IronRuby", "Boo"]

// 先頭より指定条件を満たした要素が続く間の要素から、新たなListを生成
assert  ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].takeWhile{ it.contains("#") } == ["C#", "F#"]

// 先頭より指定要素数をのぞいた新たなListを生成
assert  ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].drop(2) == ["VB", "IronPython", "IronRuby", "Boo"]

// 末尾より指定要素数をのぞいた新たなListを生成
assert  ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].dropRight(2) == ["C#", "F#", "VB", "IronPython"]

// 先頭より指定条件を満たした要素が続く間の要素を取り除いたものから、新たなListを生成
assert  ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].dropWhile{ it.contains("#" )} == ["VB", "IronPython", "IronRuby", "Boo"]

// Map生成
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].collectEntries { [it, it.length()] } ==  [Java:4, Groovy:6, Kotlin:6, Scala:5, Ceylon:6]
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].collectEntries { [it.length(), it] } ==  [4:"Java", 5:"Scala", 6:"Ceylon"]

// 先頭要素
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].first() == "Java"

// 先頭要素
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].head() == "Java"

// 先頭要素以外
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].tail() == ["Groovy", "Kotlin", "Scala", "Ceylon"]

// 末尾要素
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].last() == "Ceylon"

// 末尾要素以外
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].init() == ["Java", "Groovy", "Kotlin", "Scala"]

// 最大要素
assert [3, 1, 4, 1, 5, 9].max() == 9
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].max { it.length() } == "Groovy"

// 最小要素
assert [3, 1, 4, 1, 5, 9].min() == 1
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].min { it.length() } == "Java"

// 合計を求める
assert [3, 1, 4, 1, 5, 9].sum() == 23
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].sum { it.length() } == 27

// グループ分けして要素数え上げ
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].countBy { it.length() } ==  [4:1, 5:1, 6:3]

// インデックス(添え字)（List）
assert ["Android", "iOS", "WindowsPhone"].withIndex() == [["Android", 0], ["iOS", 1], ["WindowsPhone", 2]]

// インデックス(添え字)（Map）
assert ["Android", "iOS", "WindowsPhone"].indexed() == [0: "Android", 1:"iOS", 2:"WindowsPhone"]

// 条件を満たす1要素取得+変換
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].findResult { it.contains("#") ? "${it} has #." : null } == null
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].findResult { it.contains("#") ? "${it} has #." : null } == "C# has #."

// デフォルト値つき条件を満たす1要素取得+変換
assert ["Java", "Groovy", "Kotlin", "Scala", "Ceylon"].findResult("No Result") { it.contains("#") ? "${it} has #." : null } == "No Result"
assert ["C#", "F#", "VB", "IronPython", "IronRuby", "Boo"].findResult("No Result") { it.contains("#") ? "${it} has #." : null } == "C# has #."

// http://docs.groovy-lang.org/latest/html/groovy-jdk/java/lang/Object.html
// http://docs.groovy-lang.org/latest/html/groovy-jdk/java/lang/Object[].html
// http://docs.groovy-lang.org/latest/html/groovy-jdk/java/util/Iterator.html
// http://docs.groovy-lang.org/latest/html/groovy-jdk/java/util/Collection.html
// http://docs.groovy-lang.org/latest/html/groovy-jdk/java/util/List.html
// http://docs.groovy-lang.org/latest/html/groovy-jdk/java/util/Set.html
// http://docs.groovy-lang.org/latest/html/groovy-jdk/java/util/Map.html