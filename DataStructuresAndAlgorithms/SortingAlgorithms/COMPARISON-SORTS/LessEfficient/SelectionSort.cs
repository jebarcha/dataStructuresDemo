using System;

namespace DataStructuresAndAlgorithms.SortingAlgorithms;
public class SelectionSort
{
    public void Sort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var minIndex = FindMinMindex(i, array);
            Swap(array, minIndex, i);
        }
    }
    private int FindMinMindex(int index1, int[] array)
    {
        var minIndex = index1;
        for (int j = index1; j < array.Length; j++)
        {
            if (array[j] < array[minIndex])
                minIndex = j;
        }
        return minIndex;
    }
    private void Swap(int[] array, int index1, int index2)
    {
        var temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}
