using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayGenerator;

public class StringArrayGenerator
{
    public List<string> Generate(int length)
    {
        var array = new List<string>();
        Random randNum = new Random();
        for (int i = 0; i < length; i++)
        {
            array.Add(GetRandomString(10));
        }

        return array;
    }

    private string GetRandomString(int length)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}