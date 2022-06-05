using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace quicksort;

public class QuickSort<T>
{
    private int _tasks;
    private int _tasksMaxCount;
    
    public long Quicksort(List<T> array)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        Sort(array, 0, array.Count-1);
        
        stopwatch.Stop();
        return  stopwatch.ElapsedTicks * 1000000 / Stopwatch.Frequency;
    }
    public List<T> QuicksortParallel(List<T> array, int tasksMaxCount)
    {
        _tasks = 0;
        _tasksMaxCount = tasksMaxCount;
        
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        ParallelSort(array, 0, array.Count-1);
        
        stopwatch.Stop();
        
        Console.WriteLine("par time: " + stopwatch.ElapsedTicks * 1000000 / Stopwatch.Frequency);
        return array;


    }
    private void ParallelSort(List<T> array, int first, int last)
    {
        if (last <= first)
            return;

        if (_tasks >= _tasksMaxCount)
            Sort(array, first, last);
        else
        {
            var pivotIndex  = PivotSort(array, first, last);
            
            _tasks += 2;
            
            Parallel.Invoke(
                () => ParallelSort(array, first, pivotIndex - 1),
                () => ParallelSort(array, pivotIndex + 1, last)
            );
            
            
        }
    }

    private void Sort(List<T> array, int first, int last)
    {
        if (first < last)
        {
            var pivotIndex  = PivotSort(array, first, last);
 
            Sort(array, first, pivotIndex  - 1);
            Sort(array, pivotIndex  + 1, last);
        }
    }
    private int PivotSort (List<T> array, int f, int l)
    {
        Comparer<T> comparer = Comparer<T>.Default; 
        
        T pivot = array[l];
        int i = f - 1; 
 
        for (int j = f; j <= l - 1; j++)
        {
            if (comparer.Compare(array[j], pivot) < 0  )
            {
                i++;
                (array[i], array[j]) = (array[j], array[i]);
            }
        }
        (array[i + 1], array[l]) = (array[l], array[i + 1]);
        return i + 1;
    }
}