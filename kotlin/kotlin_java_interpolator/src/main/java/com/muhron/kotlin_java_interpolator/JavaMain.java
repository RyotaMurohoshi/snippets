package com.muhron.kotlin_java_interpolator;

import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;

public class JavaMain {
    public static void main(String[] args) {

        Iterable<Integer> iterable = KotlinCollections.getIterable();
        System.out.println(iterable.getClass().getName());

        Iterable<Integer> mutableIterable = KotlinCollections.getMutableIterable();
        System.out.println(mutableIterable.getClass().getName());

        Iterator<Integer> iterator = KotlinCollections.getIterator();
        System.out.println(iterator.getClass().getName());

        Iterator<Integer> mutableIterator = KotlinCollections.getMutableIterator();
        System.out.println(mutableIterator.getClass().getName());

        List<Integer> list = KotlinCollections.getList();
        System.out.println(list.getClass().getName());

        List<Integer> mutableList = KotlinCollections.getMutableList();
        System.out.println(mutableList.getClass().getName());

        Set<Integer> set = KotlinCollections.getSet();
        System.out.println(set.getClass().getName());

        Set<Integer> mutableSet = KotlinCollections.getMutableSet();
        System.out.println(mutableSet.getClass().getName());

        Map<Integer, Integer> map = KotlinCollections.getMap();
        System.out.println(map.getClass().getName());

        Map<Integer, Integer> mutableMap = KotlinCollections.getMutableMap();
        System.out.println(mutableMap.getClass().getName());
    }
}
