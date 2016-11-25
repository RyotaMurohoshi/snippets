package com.muhron.kotlin_java_interpolator;

import org.jetbrains.annotations.NotNull;
import org.jetbrains.annotations.Nullable;

public class Utility {
    public static String returnStringNonNull() {
        return "";
    }

    public static String returnStringNull() {
        return null;
    }

    @Nullable
    public static String returnStringWithNullableAnnotation() {
        return "";
    }

    @NotNull
    public static String returnStringWithNotNullAnnotation() {
        return "";
    }
}
