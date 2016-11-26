

```
fun example() {
    val message : String = Utility.returnStringNonNull()
    println(message)
}
```

```
   public static final void example() {
      String var10000 = Utility.returnStringNonNull();
      Intrinsics.checkExpressionValueIsNotNull(var10000, "Utility.returnStringNonNull()");
      String message = var10000;
      System.out.println(message);
   }
```



[kotlin.jvm.internal.Intrinsics](https://github.com/JetBrains/kotlin/blob/1.0.5/core/runtime.jvm/src/kotlin/jvm/internal/Intrinsics.java)クラスの[checkExpressionValueIsNotNull](https://github.com/JetBrains/kotlin/blob/1.0.5/core/runtime.jvm/src/kotlin/jvm/internal/Intrinsics.java#L86)メソッドを挿入している。

このメソッドを参照しているのは、リポジトリ中で

* [AsmUtil](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/AsmUtil.java)
* [GenerateNotNullAssertionsTest](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/tests/org/jetbrains/kotlin/codegen/GenerateNotNullAssertionsTest.java)
* [ExpressionCodegen (not 1.0.5)](https://github.com/JetBrains/kotlin/blob/fd2655fd4a533c065c0d492349b6d22125f30f33/compiler/ir/backend.jvm/src/org/jetbrains/kotlin/backend/jvm/codegen/ExpressionCodegen.kt)
* [kotlin-runtime.txt](https://github.com/JetBrains/kotlin/blob/1.0.5/libraries/tools/binary-compatibility-validator/reference-public-api/kotlin-runtime.txt)

[AsmUtil#genNotNullAssertions](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/AsmUtil.java#L650)

メソッド内を追う。


[ExpressionCodegen#genQualified](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/ExpressionCodegen.java#L291)

と

[FunctionCodegen#genDelegate](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/FunctionCodegen.java#L1029)

内で、AsmUtil#genNotNullAssertionsを呼んでいる。




「https://github.com/JetBrains/kotlin/blob/1.0.5/core/builtins/native/kotlin/Collections.kt」