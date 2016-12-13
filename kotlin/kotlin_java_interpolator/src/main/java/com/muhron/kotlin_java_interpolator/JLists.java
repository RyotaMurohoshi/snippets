package com.muhron.kotlin_java_interpolator;

import org.jetbrains.annotations.Mutable;
import org.jetbrains.annotations.NotNull;
import org.jetbrains.annotations.ReadOnly;

import java.util.ArrayList;
import java.util.List;

public class JLists {
    @NotNull
    @Mutable
    public static List<String> getMutableList() {
        return new ArrayList<>();
    }

    @NotNull
    @ReadOnly
    public static List<String> getReadonlyList() {
        return new ArrayList<>();
    }

//    @NotNull
    public static List<String> getList() {
        return new ArrayList<>();
    }

    @NotNull
    public static ArrayList<String> getArrayList() {
        return new ArrayList<>();
    }
}
