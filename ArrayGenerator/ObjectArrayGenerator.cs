using System;
using System.Collections.Generic;

namespace ArrayGenerator;

public class ObjectArrayGenerator
{
    public List<MyObject> Generate(int length)
    {
        var array = new List<MyObject>();
        Random randNum = new Random();
        for (int i = 0; i < length; i++)
        {
            array.Add(new MyObject(randNum.Next(0, length*2)));
        }
        
        return array;

    }
}