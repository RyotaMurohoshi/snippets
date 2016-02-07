package com.mrstar.is_property.kotlin

import com.mrstar.is_property.java.GetterExample
import com.mrstar.is_property.java.GetterSetterExample
import com.mrstar.is_property.java.SetterExample

fun main(args: Array<String>) {
    val getterExample = GetterExample()

    println(getterExample.name)
    println(getterExample.enabled0)
    println(getterExample.isEnabled1)
    println(getterExample.is_enabled2)
    println(getterExample.isenabled3)
    println(getterExample._enabled4)

    println(getterExample.getEnabled0())
    println(getterExample.isEnabled1())
    println(getterExample.is_enabled2())
    println(getterExample.getIsenabled3())
    println(getterExample.get_enabled4())
    println(getterExample.isenabled5())
    println(getterExample.getenabled6())

    val setterExample = SetterExample()
    setterExample.setEnabled0(true)
    setterExample.set_enabled1(true)
    setterExample.setenabled2(true)
    setterExample.enabled3(true)

    val getterSetterExample = GetterSetterExample()
    println(getterSetterExample.name)
    println(getterSetterExample.enabled0)
    println(getterSetterExample.isEnabled1)
    println(getterSetterExample.is_enabled2)
    println(getterSetterExample.isenabled3)
    println(getterSetterExample._enabled4)

    println(getterSetterExample.getEnabled0())
    println(getterSetterExample.isEnabled1())
    println(getterSetterExample.is_enabled2())
    println(getterSetterExample.getIsenabled3())
    println(getterExample.get_enabled4())
    println(getterSetterExample.isenabled5())
    println(getterSetterExample.getenabled6())

    getterSetterExample.enabled0 = true
    getterSetterExample.isEnabled1 = true
    getterSetterExample.is_enabled2 = true
    getterSetterExample.isenabled3 = true
    getterSetterExample._enabled4 = true

    getterSetterExample.setEnabled0(true)
    getterSetterExample.setEnabled1(true)
    getterSetterExample.set_enabled2(true)
    getterSetterExample.setIsenabled3(true)
    getterSetterExample.set_enabled4(true)
    getterSetterExample.isenabled5(true)
    getterSetterExample.setenabled6(true)

    val person = Person("Ryota", 27)
    println(person.name)
    println(person.age)

    // person.name = "RyotaMurohoshi"
    person.age = 28

    println(person.name)
    println(person.age)
}
