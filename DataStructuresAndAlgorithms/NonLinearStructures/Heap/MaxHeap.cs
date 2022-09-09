using System;

namespace DataStructuresAndAlgorithms.NonLinearStructures.Heap;

public class MaxHeap
{
    public static void Heapify(int[] array)
    {
        int lastParentIndex = array.Length / 2 - 1;
        for (int i = lastParentIndex; i >= 0; i--)
        {
            Heapify(array, i);
        }
    }
    private static void Heapify(int[] array, int index)
    {
        var largerIndex = index;
        var leftIndex = index * 2 + 1;
        if (leftIndex < array.Length && array[leftIndex] > array[largerIndex])
        {
            largerIndex = leftIndex;
        }

        var rightIndex = index * 2 + 2;
        if (rightIndex < array.Length && array[rightIndex] > array[largerIndex])
        {
            largerIndex = rightIndex;
        }

        if (index == largerIndex)
        {
            return;
        }

        Swap(array, index, largerIndex);
        Heapify(array, largerIndex);
    }

    private static void Swap(int[] array, int first, int second)
    {
        var temp = array[first];
        array[first] = array[second];
        array[second] = temp;
    }

    public static int GetKthLargest(int[] array, int k)
    {
        if (k < 1 || k > array.Length)
        {
            throw new ArgumentOutOfRangeException();
        }

        var heap = new MyHeap();
        foreach (var number in array)
        {
            heap.Insert(number);
        }

        for (int i = 0; i < k - 1; i++)
        {
            heap.Remove();
        }

        return heap.Max();
    }

    public static bool IsMaxHeap(int[] array)
    {
        return IsMaxHeap(array, 0);
    }

    private static bool IsMaxHeap(int[] array, int index)
    {
        // All leaf nodes are valid
        var lastParentIndex = (array.Length - 2) / 2;
        if (index > lastParentIndex)
            return true;

        var leftChildIndex = index * 2 + 1;
        var rightChildIndex = index * 2 + 2;

        var isValidParent =
            array[index] >= array[leftChildIndex] &&
            (rightChildIndex <= index && array[index] >= array[rightChildIndex]);

        return isValidParent &&
                IsMaxHeap(array, leftChildIndex) &&
                IsMaxHeap(array, rightChildIndex);
    }
}
