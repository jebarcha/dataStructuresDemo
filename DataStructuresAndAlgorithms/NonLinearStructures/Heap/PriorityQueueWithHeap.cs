namespace DataStructuresAndAlgorithms.NonLinearStructures.Heap;

public class PriorityQueueWithHeap
{
    // This class is a wrapper around the MyHeap class
    private MyHeap _heap;

    public void Enqueue(int item) => _heap.Insert(item);
    public int Dequeue() => _heap.Remove();
    public bool IsEmpty() => _heap.IsEmpty();

}
