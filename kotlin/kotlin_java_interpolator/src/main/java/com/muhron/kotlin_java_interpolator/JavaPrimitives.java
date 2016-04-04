package com.muhron.kotlin_java_interpolator;

import sun.misc.FloatConsts;
import sun.plugin.dom.exception.InvalidStateException;

/**
 * Created by ryota on 2016/04/04.
 */
public class JavaPrimitives {
    private JavaPrimitives() {
        throw new InvalidStateException("use as utility class.");
    }

    public static Short getShorWrapper() {
        return 1;
    }

    public static short getShortPrimitive() {
        return 1;
    }

    public static Integer getIntWrapper() {
        return 0;
    }

    public static int getIntPrimitive() {
        return 0;
    }

    public static Long getLongWrapper() {
        return 1L;
    }

    public static long getLontPrimitive() {
        return 1L;
    }

    public static Float getFloatWrapper() {
        return 0.0F;
    }

    public static float getFloawtPrimitive() {
        return 0.0F;
    }

    public static Double getDoubleWrapper() {
        return 0.0;
    }

    public static double getDoublePrimitive() {
        return 0.0;
    }

    public static Character getCharWrapper() {
        return 'a';
    }

    public static char getCharPrimitive() {
        return 'a';
    }

    public static Boolean getBooleanWrapper() {
        return true;
    }

    public static boolean getBooleanPrimitive() {
        return false;
    }
}
