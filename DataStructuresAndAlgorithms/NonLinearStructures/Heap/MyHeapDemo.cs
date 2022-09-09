using DataStructuresAndAlgorithms.DataUtils;

namespace DataStructuresAndAlgorithms.NonLinearStructures.Heap;

public static class MyHeapDemo
{
    public static void Demo()
    {
        //InsertDemo();
        //HeapSort();
        //HeapifyDemo();
        MinHeapDemo();


        Console.WriteLine("Done");
    }
    private static void HeapSort()
    {
        int[] numbers = { 5, 3, 10, 1, 4, 2 };
        var heap = new MyHeap();
        foreach (var number in numbers)
        {
            heap.Insert(number);
        }

        //for (int i = 0; i < numbers.Length; i++)
        //{
        //    numbers[i] = heap.Remove();
        //}
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            numbers[i] = heap.Remove();
        }

        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }

    }
    private static void InsertDemo()
    {
        MyHeap heap = new MyHeap();
        heap.Insert(10);
        heap.Insert(5);
        heap.Insert(17);
        heap.Insert(4);
        heap.Insert(22);
        Console.WriteLine($"heap.Remove(): {heap.Remove()}");
    }
    private static void HeapifyDemo()
    {
        int[] numbers = { 5, 3, 8, 4, 1, 2 };
        //in a heap every node should be greater than of equal to its children.
        //Create a Heapify method
        MaxHeap.Heapify(numbers);
        Console.WriteLine(Utils.Array2String(numbers));
        //Console.WriteLine($"GetKthLargest: {MaxHeap.GetKthLargest(numbers, 2)}");
        //Console.WriteLine($"IsMaxHeap: {MaxHeap.IsMaxHeap(numbers)}");
    }
    private static void MinHeapDemo()
    {
        var minHeap = new MinHeap();
        minHeap.Insert(0, "10");
        minHeap.Insert(1, "20");
        minHeap.Insert(2, "30");
        minHeap.Remove();


        var minPriorityQueue = new MinPriorityQueue();
        minPriorityQueue.Add("10", 10);
        minPriorityQueue.Add("20", 20);
        minPriorityQueue.Add("30", 30);
        minPriorityQueue.Add("40", 40);

    }


}
