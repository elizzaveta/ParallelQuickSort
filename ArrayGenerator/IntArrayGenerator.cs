using System;
using System.Collections.Generic;

namespace ArrayGenerator;

public class IntArrayGenerator
{
    public List<int> Generate(int length)
    {
        var array = new List<int>();
        Random randNum = new Random();
        for (int i = 0; i < length; i++)
        {
            array.Add(randNum.Next(0, length*2));
        }

        return array;
    }
}