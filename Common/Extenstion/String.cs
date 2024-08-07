﻿namespace Common;
public static class StringExtension
{
    public static string Bold(this string input) => $"* {input} *";
    public static string NewLineBefore(this string input,int count=1)
    {
        for (int i = 0; i < count; i++) input = "\n" + input;
        return input;
    }
    public static string NewLineAfter(this string input, int count = 1)
    {
        for (int i = 0; i < count; i++) input += "\n";
        return input;
    }
}
