using System;

namespace DataStructuresAndAlgorithms.Algorithms.SearchAlgorithms;
public class Search
{
    public int LinearSearch(int[] array, int target)
    {
        for (int i = 0; i < array.Length; i++)
            if (array[i] == target)
                return i;

        return -1;
    }
    
    public int BinarySearchIterative(int[] array, int target)
    {
        var left = 0;
        var right = array.Length - 1;

        while (left <= right)
        {
            var middle = (left + right) / 2;

            if (array[middle] == target)
                return middle;

            if (target < array[middle])
                right = middle - 1;
            else
                left = middle + 1;
        }
        
        return -1;
    }

    public int BinarySearchRecursive(int[] array, int target)
    {
        return BinarySearchRecursive(array, target, 0, array.Length - 1);
    }
    private int BinarySearchRecursive(int[] array, int target, int left, int right)
    {
        if (right < left)
            return -1;

        int middle = (left + right) / 2;

        if (array[middle] == target)
            return middle;

        if (target < array[middle])
            return BinarySearchRecursive(array, target, left, middle - 1);

        return BinarySearchRecursive(array, target, middle + 1, right);
    }


    public int TernarySearchRecursive(int[] array, int target)
    {
        var left = 0;
        var right = array.Length - 1;

        return TernarySearchRecursive(array, target, left, right);
    }
    private int TernarySearchRecursive(int[] array, int target, int left, int right)
    {
        if (left > right)
            return -1;

        int partitionSize = (right - left) / 3;
        int mid1 = left + partitionSize;
        int mid2 = right - partitionSize;

        if (array[mid1] == target)
            return mid1;

        if (array[mid2] == target)
            return mid2;

        if (target < array[mid1])
            return TernarySearchRecursive(array, target, left, mid1 - 1);

        if (target > array[mid2])
            return TernarySearchRecursive(array, target, mid2 + 1, right);

        return TernarySearchRecursive(array, target, mid1 + 1, mid2 - 1);

    }


    public int JumpSearch(int[] array, int target)
    {
        int blockSize = (int)Math.Sqrt(array.Length);
        int start = 0;
        int next = blockSize;

        while (start < array.Length && 
            array[next - 1] < target)
        {
            start = next;
            next += blockSize;
            if (next > array.Length)
                next = array.Length;
        }

        for (int i = start; i < next; i++)
        {
            if (array[i] == target)
                return i;
        }
        return -1;
    }

    public int ExponentialSearch(int[] array, int target)
    {
        int bound = 1;
        while (bound < array.Length && array[bound] < target)
            bound *= 2;

        var left = bound / 2;
        var right = Math.Min(bound, array.Length - bound);
        return BinarySearchRecursive(array, target, left, right);
    }

}
