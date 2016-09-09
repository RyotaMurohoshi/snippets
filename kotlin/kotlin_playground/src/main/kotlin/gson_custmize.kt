package com.mrstar.kotlin_playground

import com.google.gson.*
import java.lang.reflect.Type

data class Character(val id: Id, val name: String)

data class Id(val value: Long)

class IdSerializer : JsonSerializer<Id> {
    override fun serialize(src: Id, typeOfSrc: Type, context: JsonSerializationContext): JsonElement
            = JsonPrimitive(src.value)
}

class IdDeserializer : JsonDeserializer<Id> {
    override fun deserialize(json: JsonElement, typeOfT: Type, context: JsonDeserializationContext): Id
            = Id(json.asLong)
}

fun main(args: Array<String>) {
    val gson = GsonBuilder()
            .registerTypeAdapter(Id::class.java, IdSerializer())
            .registerTypeAdapter(Id::class.java, IdDeserializer())
            .create()
    println(gson.toJson(Id(1L)))

    val character = """{"name":"Ryota", "id":0}"""
    println(gson.fromJson(character, Character::class.java))
}
