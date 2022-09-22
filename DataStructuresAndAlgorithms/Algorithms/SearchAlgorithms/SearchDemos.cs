namespace DataStructuresAndAlgorithms.Algorithms.SearchAlgorithms;

public static class SearchDemos
{
    public static void Demos()
    {
        //LinearSearch();
        //BinarySearchRecursive();
        //BinarySearchIterative();
        //TernarySearchRecursive();
        //JumpSearch();
        ExponentialSearch();
    }
    public static void LinearSearch()
    {
        int[] numbers = { 7, 1, 3, 6, 5};
        var search = new Search();
        var index = search.LinearSearch(numbers, 3);
        Console.WriteLine($"index: {index}");
    }

    public static void BinarySearchRecursive()
    {
        int[] numbers = { 1, 3, 5, 6, 7 };
        var search = new Search();
        var index = search.BinarySearchRecursive(numbers, 1);
        Console.WriteLine($"BinarySearchRecursive: {index}");

    }
    public static void BinarySearchIterative()
    {
        int[] numbers = { 1, 3, 5, 6, 7 };
        var search = new Search();
        var index = search.BinarySearchIterative(numbers, 7);
        Console.WriteLine($"BinarySearchIterative: {index}");
    }
    public static void TernarySearchRecursive()
    {
        int[] numbers = { 1, 3, 5, 6, 7 };
        var search = new Search();
        var index = search.TernarySearchRecursive(numbers, 1);
        Console.WriteLine($"TernarySearchRecursive: {index}");
    }
    public static void JumpSearch()
    {
        int[] numbers = { 1, 3, 5, 6, 7 };
        var search = new Search();
        var index = search.JumpSearch(numbers, 1);
        Console.WriteLine($"JumpSearch: {index}");
    }
    public static void ExponentialSearch()
    {
        int[] numbers = { 1, 3, 5, 6, 7 };
        var search = new Search();
        var index = search.ExponentialSearch(numbers, 5);
        Console.WriteLine($"JumpSearch: {index}");
    }



}
