package com.mrstar.is_property.groovy

import com.mrstar.is_property.java.GetterExample
import com.mrstar.is_property.java.SetterExample
import com.mrstar.is_property.java.GetterSetterExample

def getterExample = new GetterExample()

println(getterExample.name)
println(getterExample.enabled0)
//println(getterExample.isEnabled1)
//println(getterExample.is_enabled2)
println(getterExample.isenabled3)
println(getterExample._enabled4)

println(getterExample.getEnabled0())
println(getterExample.isEnabled1())
println(getterExample.is_enabled2())
println(getterExample.getIsenabled3())
println(getterExample.get_enabled4())
println(getterExample.isenabled5())
println(getterExample.getenabled6())

def setterExample = new SetterExample()
setterExample.enabled0 = true
setterExample._enabled1 = true

setterExample.setEnabled0(true)
setterExample.set_enabled1(true)
setterExample.setenabled2(true)
setterExample.enabled3(true)

def getterSetterExample = new GetterSetterExample()
println(getterSetterExample.name)
println(getterSetterExample.enabled0)
//println(getterSetterExample.isEnabled1)
//println(getterSetterExample.is_enabled2)
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
//getterSetterExample.isEnabled1 = true
//getterSetterExample.is_enabled2 = true
getterSetterExample.isenabled3 = true
getterSetterExample._enabled4 = true

getterSetterExample.setEnabled0(true)
getterSetterExample.setEnabled1(true)
getterSetterExample.set_enabled2(true)
getterSetterExample.setIsenabled3(true)
getterSetterExample.set_enabled4(true)
getterSetterExample.isenabled5(true)
getterSetterExample.setenabled6(true)