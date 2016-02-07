package com.mrstar.ixjava_example;

import ix.Ix;

import java.util.Arrays;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        // http://qiita.com/amay077/items/612d91458d21979aaced

        List<Integer> results = Ix.from(Arrays.asList(0, 1, 2, 3, 4, 5, 6, 7, 8, 9))
                .filter(x -> x % 2 == 0)
                .orderBy(x-> -x)
                .map(x -> x * 10)
                .toList();

        System.out.println(results);
        System.out.println(results.getClass().getName());

        List<Integer> intNums = Ix
                .range(0, Integer.MAX_VALUE)
                .scan(0, (acc, elem) -> acc + elem)
                .take(10)
                .toList();

        System.out.println(intNums);

        String[] languages = new String[]{"Java", "Groovy", "Scala", "Kotlin", "Ceylon", "Xtend"};
        System.out.println(Ix.from(languages));
    }
}
