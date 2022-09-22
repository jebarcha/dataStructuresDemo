using DataStructuresAndAlgorithms.DataUtils;
using DataStructuresAndAlgorithms.SortingAlgorithms.MoreEfficient;
using DataStructuresAndAlgorithms.SortingAlgorithms.NON_COUNTING_SORTS;

namespace DataStructuresAndAlgorithms.SortingAlgorithms;

public static class SortDemos
{
    public static void Demos()
    {
        //BubbleSort();
        //SelectionSort();
        //InsertionSort();

        //MergeSort();
        //QuickSort();

        //CountingSort();
        BucketSort();


    }

    #region NonComparisonSorts
    public static void BucketSort()
    {
        int[] numbers = { 7, 1, 3, 5, 3 };
        Console.WriteLine($"Original: {Utils.Array2String(numbers)}");

        var sorter = new BucketSort();
        sorter.Sort(numbers, 3);
        Console.WriteLine($"BucketSort: {Utils.Array2String(numbers)}");
    }
    public static void CountingSort()
    {
        int[] numbers = { 5, 1, 7, 2, 6, 4 };
        Console.WriteLine($"Original: {Utils.Array2String(numbers)}");

        var sorter = new CountingSort();
        sorter.Sort(numbers, 7);
        Console.WriteLine($"Sorted: {Utils.Array2String(numbers)}");
    }
    #endregion


    #region moreEfficient
    public static void QuickSort()
    {
        Console.WriteLine("QuickSort");
        int[] numbers = { 7, 3, 1, 5, 2 };
        Console.WriteLine($"Original: {Utils.Array2String(numbers)}");
        
        var sorter = new QuickSort();
        sorter.Sort(numbers);
        Console.WriteLine($"Sorted: {Utils.Array2String(numbers)}");
    }
    public static void MergeSort()
    {
        Console.WriteLine("MergeSort");
        int[] numbers = { 7, 3, 5, 2, 3, 1, 5, 8 };
        Console.WriteLine($"Original: {Utils.Array2String(numbers)}");
        var selectionSort = new MergeSort();
        selectionSort.Sort(numbers);
        Console.WriteLine($"Sorted: {Utils.Array2String(numbers)}");
    }


    #endregion

    #region LessEfficient
    public static void InsertionSort()
    {
        Console.WriteLine("InsertionSort");
        int[] numbers = { 7 , 3, 5, 2, 3, 1, 5, 8 };
        Console.WriteLine($"Original: {Utils.Array2String(numbers)}");
        var selectionSort = new InsertionSort();
        selectionSort.Sort(numbers);
        Console.WriteLine($"Sorted: {Utils.Array2String(numbers)}");

    }
    public static void SelectionSort()
    {
        Console.WriteLine("SelectionSort");
        int[] numbers = { 7, 3, 1, 4, 6, 2, 3 };
        Console.WriteLine($"Original: {Utils.Array2String(numbers)}");
        var selectionSort = new SelectionSort();
        selectionSort.Sort(numbers);
        Console.WriteLine($"Sorted: {Utils.Array2String(numbers)}");

    }
    public static void BubbleSort()
    {
        Console.WriteLine("BubbleSort");
        int[] numbers = { 7, 3, 1, 4, 6, 2, 3 };
        Console.WriteLine($"Original: {Utils.Array2String(numbers)}");
        var bubble = new BubbleSort();
        bubble.Sort(numbers);
        Console.WriteLine($"Sorted: {Utils.Array2String(numbers)}");
    }
    #endregion
}
