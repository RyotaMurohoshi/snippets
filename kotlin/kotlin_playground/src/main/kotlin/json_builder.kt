package com.mrstar.kotlin_playground

import com.github.salomonbrys.kotson.*;
import com.google.gson.JsonObject

fun main(args: Array<String>) {

    val jsonObject: JsonObject = jsonObject(
            "name" to "Mrstar",
            "job" to "programmer",
            "languages" to jsonArray(
                    "Java",
                    "Kotlin",
                    "Groovy",
                    "C#"
            )
    )

    println(jsonObject.toString())
}