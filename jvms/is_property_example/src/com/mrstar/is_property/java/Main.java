package com.mrstar.is_property.java;
import com.mrstar.is_property.groovy.GData;
import com.mrstar.is_property.kotlin.KData;
import com.mrstar.is_property.kotlin.KData0;
import com.mrstar.is_property.kotlin.KData1;
import com.mrstar.is_property.kotlin.Person;

public class Main {
    public static void main(String[] args) {
        {
            KData data = new KData("Kotlin", "", "", false, false, false, false, false);

            System.out.println(data.getName());
            System.out.println(data.isString0());
            System.out.println(data.is_string1());
            System.out.println(data.getEnabled0());
            System.out.println(data.isEnabled1());
            System.out.println(data.is_enabled2());
            System.out.println(data.getIsenabled3());
            System.out.println(data.getHasEnabled());

            data.setName("Kotlin!");
            data.setEnabled0(true);
            data.setEnabled1(true);
            data.set_enabled2(true);
            data.setIsenabled3(true);
            data.setString0("");
            data.set_string1("");
            data.setHasEnabled(true);

            System.out.println(data.getName());
            System.out.println(data.getEnabled0());
            System.out.println(data.isEnabled1());
            System.out.println(data.is_enabled2());
            System.out.println(data.getIsenabled3());
            System.out.println(data.getHasEnabled());
        }

        {
            GData data = new GData();

            System.out.println(data.getName());
            System.out.println(data.isEnabled0());
            System.out.println(data.isIsEnabled1());
            System.out.println(data.isIs_enabled2());
            System.out.println(data.isIsenabled3());
            System.out.println(data.getEnabled0());
            System.out.println(data.getIsEnabled1());
            System.out.println(data.getIs_enabled2());
            System.out.println(data.getIsenabled3());

            data.setName("Groovy!");
            data.setEnabled0(true);
            data.setIsEnabled1(true);
            data.setIs_enabled2(true);
            data.setIsenabled3(true);

            System.out.println(data.getName());
            System.out.println(data.isEnabled0());
            System.out.println(data.isIsEnabled1());
            System.out.println(data.isIs_enabled2());
            System.out.println(data.isIsenabled3());
            System.out.println(data.getEnabled0());
            System.out.println(data.getIsEnabled1());
            System.out.println(data.getIs_enabled2());
            System.out.println(data.getIsenabled3());
        }

        {
            Person person = new Person("Ryota", 27);
            System.out.println(person.getName());
            System.out.println(person.getAge());

            // person.setName("Super Ryota");
            person.setAge(28);

            System.out.println(person.getName());
            System.out.println(person.getAge());
        }

        {
            KData0 kData0 = new KData0(true, "xxxxx");
            System.out.println(kData0.isValid());
            System.out.println(kData0.isEnabled());

            kData0.setEnabled(true);
            kData0.setValid("fffff");
        }

        {
            KData1 kData1 = new KData1(true, "xxxxx");
            System.out.println(kData1.is_valid());
            System.out.println(kData1.is_enabled());

            kData1.set_enabled(true);
            kData1.set_valid("fffff");
        }
    }
}
