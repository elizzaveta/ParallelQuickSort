// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using ArrayGenerator;
using quicksort;


// place to call additional test functions

// RunObjectTest(500, 64);
// RunStringTest(1000, 4);
// RunObjectTest(1000, 4);

// ParallelQuickSortIntArrayTest(10000, 4);
// ParallelQuickSortStringArrayTest(500, 4);
// ParallelQuickSortObjectArrayTest(10000, 4);



////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// additional functions
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// print given array
void PrintArray<T>(List<T> array)
{
    int numbersInARow = 0;
    foreach (var item in array)
    {
        Console.Write(item?.ToString() ?? string.Empty);
        Console.Write(", ");
        numbersInARow++;
        if (numbersInARow == 30)
        {
            Console.WriteLine();
            numbersInARow = 0;
        }
    }
}

// get int array sort time | parallel and sequential algorithms
void RunIntTest(int elements, int tasksMaxCount)
{
    var intArrayGenerator = new IntArrayGenerator();
    var intArray = intArrayGenerator.Generate(elements);

    var sorter = new QuickSort<int>();
    
    var time = sorter.QuicksortParallel(intArray.ToList(), tasksMaxCount);
    var time2 = sorter.Quicksort(intArray.ToList());
    
    Console.WriteLine("seq time: " + time2);
    Console.WriteLine("elements: " + elements +"\n");
    Console.WriteLine("tasks: " + tasksMaxCount +"\n");
}

// get string array sort time | parallel and sequential algorithms
void RunStringTest(int elements, int tasksMaxCount)
{
    var stringArrayGenerator = new StringArrayGenerator();
    var stringArray = stringArrayGenerator.Generate(elements);
    
    var sorter = new QuickSort<string>();
    
    var time = sorter.QuicksortParallel(stringArray.ToList(),tasksMaxCount);
    var time2 = sorter.Quicksort(stringArray.ToList());
    
    Console.WriteLine("seq time: " + time2);
    Console.WriteLine("elements: " + elements +"\n");
}

// get object array sort time | parallel and sequential algorithms
void RunObjectTest(int elements, int tasksMaxCount)
{
    var objectGenerator = new ObjectArrayGenerator();
    var objectArray = objectGenerator.Generate(elements);
    
    var sorter = new QuickSort<MyObject>();
    
    var time = sorter.QuicksortParallel(objectArray.ToList(), tasksMaxCount);
    var time2 = sorter.Quicksort(objectArray.ToList());
    
    Console.WriteLine("seq time: " + time2);
    Console.WriteLine("elements: " + elements +"\n");
}

// test if parallel algorithm sorts int arrays correctly
void ParallelQuickSortIntArrayTest(int elements, int tasksMaxCount)
{
    var intArrayGenerator = new IntArrayGenerator();
    var intArray = intArrayGenerator.Generate(elements);

    var sorter = new QuickSort<int>();
    
    var sorted = sorter.QuicksortParallel(intArray.ToList(), tasksMaxCount);
    
    Console.WriteLine($"\nint array, {elements} elements");
    Console.WriteLine($"number of tasks: {tasksMaxCount}");
    Console.WriteLine($"is array sorted: {CheckSortedArray(sorted)}");
}

// test if parallel algorithm sorts string arrays correctly
void ParallelQuickSortStringArrayTest(int elements, int tasksMaxCount)
{
    var stringArrayGenerator = new StringArrayGenerator();
    var stringArray = stringArrayGenerator.Generate(elements);
    
    var sorter = new QuickSort<string>();
    
    var sorted = sorter.QuicksortParallel(stringArray.ToList(),tasksMaxCount);
    
    Console.WriteLine($"\nstring array, {elements} elements");
    Console.WriteLine($"number of tasks: {tasksMaxCount}");
    Console.WriteLine($"is array sorted: {CheckSortedArray(sorted)}");
}

// test if parallel algorithm sorts object arrays correctly
void ParallelQuickSortObjectArrayTest(int elements, int tasksMaxCount)
{
    var objectGenerator = new ObjectArrayGenerator();
    var objectArray = objectGenerator.Generate(elements);
    
    var sorter = new QuickSort<MyObject>();
    
    var sorted = sorter.QuicksortParallel(objectArray.ToList(), tasksMaxCount);

    Console.WriteLine($"\nobject array, {elements} elements");
    Console.WriteLine($"number of tasks: {tasksMaxCount}");
    Console.WriteLine($"is array sorted: {CheckSortedArray(sorted)}");
}

// check if given array is sorted correctly
bool CheckSortedArray<T>(List<T> array)
{
    var arrayCopy = array.ToList();
    arrayCopy.Sort();

    return arrayCopy.SequenceEqual(array);
}