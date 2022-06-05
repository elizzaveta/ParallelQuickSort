using System;

namespace ArrayGenerator;

public class MyObject : IComparable
{
    private int number;

    public MyObject(int n)
    {
        number = n;
    }

    public override string ToString()
    {
        return number.ToString();
    }

    public int CompareTo(object? obj)
    {
        if (obj is MyObject myObject)
        {
            return number.CompareTo(myObject.number);
        }
        throw new ArgumentException("Incorrect parameter value.");
        
    }

    public override bool Equals(object? obj)
    {
        if (obj is MyObject myObject)
        {
            return number == myObject.number;
        }
        throw new ArgumentException("Incorrect parameter value.");
    }
    public override int GetHashCode()
    {
        return number;
    }
}