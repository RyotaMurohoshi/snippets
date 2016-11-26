* [公式ドキュメント(Working with the Command Line Compiler)](https://kotlinlang.org/docs/tutorials/command-line.html)
* [【コードリーディング】Kotlin to JavaScriptコンパイラメモ](http://yyyank.blogspot.jp/2015/05/kotlinkotlin-to-javascript.html) (by [@yy_yank](https://twitter.com/yy_yank?ref_src=twsrc%5Etfw)さん)
* [Kotlin M9で追加されたPlatform Typeの話](http://taro.hatenablog.jp/entry/2014/10/16/233702)

エントリポイントからのKotlinコンパイラ、コードリーディング。

---

Kotlinのコンパイルコマンドは、

```
kotlinc hello.kt -d hello.jar
```

---

[kotlin/compiler/cli/bin/](https://github.com/JetBrains/kotlin/tree/1.0.5/compiler/cli/bin)ディレクトリの[kotlinc.bat](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/cli/bin/kotlinc.bat)の[19行目](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/cli/bin/kotlinc.bat#L19)に、

```
if "%_KOTLIN_COMPILER%"=="" set _KOTLIN_COMPILER=org.jetbrains.kotlin.cli.jvm.K2JVMCompiler 
```

という記述があった。

---

K2JVMCompiler

[org.jetbrains.kotlin.cli.jvm.K2JVMCompiler](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/cli/src/org/jetbrains/kotlin/cli/jvm/K2JVMCompiler.kt)（[CLICompiler](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/cli/src/org/jetbrains/kotlin/cli/common/CLICompiler.java)を継承している）


[main](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/cli/src/org/jetbrains/kotlin/cli/jvm/K2JVMCompiler.kt#L354)をたどると、[doExecute](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/cli/src/org/jetbrains/kotlin/cli/jvm/K2JVMCompiler.kt#L53)メソッドに。



[この中で](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/cli/src/org/jetbrains/kotlin/cli/jvm/K2JVMCompiler.kt#L182)、

```
KotlinToJVMBytecodeCompiler.compileModules(environment, directory)
```

という記述がある。

---

KotlinToJVMBytecodeCompiler

[KotlinToJVMBytecodeCompiler](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/cli/src/org/jetbrains/kotlin/cli/jvm/compiler/KotlinToJVMBytecodeCompiler.kt)クラスの[compileModules](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/cli/src/org/jetbrains/kotlin/cli/jvm/compiler/KotlinToJVMBytecodeCompiler.kt#L106)

KotlinToJVMBytecodeCompiler#compileModulesを読むと前後の文脈から、[次の処理](https://github.com/JetBrains/kotlin/blob/d335aea6821542d30840299b1a9c07468d081b62/compiler/cli/src/org/jetbrains/kotlin/cli/jvm/compiler/KotlinToJVMBytecodeCompiler.kt#L151
)に注目（この後、writeOutputって名前のメソッドを呼び出していた）

```
outputs[module] = generate(environment, moduleConfiguration, result, ktFiles, module)
```

次は、[generate](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/cli/src/org/jetbrains/kotlin/cli/jvm/compiler/KotlinToJVMBytecodeCompiler.kt#L399)メソッド。


そこでさらに読み進めると、前後の文脈から[次の処理](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/cli/src/org/jetbrains/kotlin/cli/jvm/compiler/KotlinToJVMBytecodeCompiler.kt#L455)に注目。（この後、実行時間の計測していた。）

```
KotlinCodegenFacade.compileCorrectFiles(generationState, CompilationErrorHandler.THROW_EXCEPTION)
```

---

KotlinCodegenFacade

[KotlinCodegenFacade](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/KotlinCodegenFacade.java)の[compileCorrectFiles](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/KotlinCodegenFacade.java#L34)の中の、[この箇所で](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/KotlinCodegenFacade.java#L77)generatePackageメソッドを呼び出している。

```
generatePackage(state, packageFqName, filesInPackages.get(packageFqName), errorHandler);
```

[generatePackage](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/KotlinCodegenFacade.java#L90)メソッドは次のようになっている。

```
    public static void generatePackage(
            @NotNull GenerationState state,
            @NotNull FqName packageFqName,
            @NotNull Collection<KtFile> jetFiles,
            @NotNull CompilationErrorHandler errorHandler
    ) {
        // We do not really generate package class, but use old package fqName to identify package in module-info.
        //FqName packageClassFqName = PackageClassUtils.getPackageClassFqName(packageFqName);
        PackageCodegen codegen = state.getFactory().forPackage(packageFqName, jetFiles);
        codegen.generate(errorHandler);
    }
```


[GenerationState](https://github.com/JetBrains/kotlin/blob/3471b3311f8358a14ab21d957c6137a84615484a/compiler/backend/src/org/jetbrains/kotlin/codegen/state/GenerationState.kt)クラスの[factory](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/state/GenerationState.kt#L129)プロパティは、[ClassFileFactory](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/ClassFileFactory.java)型

[forPackage](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/ClassFileFactory.java#L194)メソッドで、[PackageCodegen](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/PackageCodegen.java)型を生成する。

---

PackageCodegenの中で、

[generate](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/PackageCodegen.java#L61)
-> [generateFile](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/PackageCodegen.java#L98)
-> [generateClassOrObject](https://github.com/JetBrains/kotlin/blob/1.0.5/compiler/backend/src/org/jetbrains/kotlin/codegen/PackageCodegen.java#L145)

と注目していくと、

```
public void generateClassOrObject(@NotNull KtClassOrObject classOrObject, @NotNull PackageContext packagePartContext) {
    MemberCodegen.genClassOrObject(packagePartContext, classOrObject, state, null);
}
```

---

