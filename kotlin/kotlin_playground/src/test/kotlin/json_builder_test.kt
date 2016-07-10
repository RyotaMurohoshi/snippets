package com.mrstar.kotlin_playground

import com.github.salomonbrys.kotson.*;
import org.junit.Assert
import org.junit.Test

class JsonBuilderTest {
    @Test
    fun jsonBuildTest() {

        val actual = jsonObject(
                "name" to "Mrstar",
                "job" to "programmer",
                "languages" to jsonArray(
                        "Java",
                        "Kotlin",
                        "Groovy",
                        "C#"
                )
        )


        val expected = """{"name":"Mrstar","job":"programmer","languages":["Java","Kotlin","Groovy","C#"]}"""

        Assert.assertEquals(expected, actual)
    }
}
