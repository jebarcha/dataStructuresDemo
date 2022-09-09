using System;

namespace DataStructuresAndAlgorithms.NonLinearStructures.Heap;

public class MinPriorityQueue
{
    private MinHeap heap = new MinHeap();

    public void Add(String value, int priority) => heap.Insert(priority, value);
    public String Remove() => heap.Remove();
    public bool IsEmpty() => heap.IsEmpty();
}
