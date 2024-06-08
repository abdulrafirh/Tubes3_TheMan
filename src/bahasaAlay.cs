using System;
using System.Collections.Generic;

public sealed class AlayDetector
{
    private AlayDetector() { }

    private static readonly AlayDetector instance = new AlayDetector();

    public static AlayDetector Instance
    {
        get { return instance; }
    }

    public bool IsAlay(string firstString, string secondString)
    {
        if (string.IsNullOrEmpty(firstString) || string.IsNullOrEmpty(secondString))
        {
            return false;
        }

        firstString = firstString.ToLower();
        secondString = secondString.ToLower();

        if (firstString.Length != secondString.Length)
        {
            return false;
        }

        int j = 0;

        for (int i = 0; i < firstString.Length; i++)
        {
            char c = firstString[i];

            if (IsVowel(c))
            {
                continue;
            }

            if (j >= secondString.Length || secondString[j] != c)
            {
                return false;
            }

            j++;=
        }

        return true;
    }

    private bool IsVowel(char c)
    {
        return "aeiouAEIOU".IndexOf(c) >= 0;
    }
}