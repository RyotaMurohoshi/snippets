package com.muhron.lombok_example;

import lombok.val;

public class Main {
    public static void main(String[] args) {
        val person = new Person("Ryota", 27);

        System.out.println(person);
    }
}
