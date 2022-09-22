namespace DataStructuresAndAlgorithms.Algorithms.SearchAlgorithms;

public static class SearchDemos
{
    public static void Demos()
    {
        //LinearSearch();
        BinarySearch();

    }
    public static void LinearSearch()
    {
        int[] numbers = { 7, 1, 3, 6, 5};
        var search = new Search();
        var index = search.LinearSearch(numbers, 3);
        Console.WriteLine($"index: {index}");
    }

    public static void BinarySearch()
    {
        int[] numbers = { 1, 3, 5, 6, 7 };
        var search = new Search();
        //var index = search.BinarySearchRecursive(numbers, 1);
        //Console.WriteLine($"BinarySearchRecursive: {index}");

        //var index = search.BinarySearchIterative(numbers, 7);
        //Console.WriteLine($"BinarySearchIterative: {index}");

        //var index = search.TernarySearchRecursive(numbers, 1);
        //Console.WriteLine($"TernarySearchRecursive: {index}");

        //var index = search.JumpSearch(numbers, 1);
        //Console.WriteLine($"JumpSearch: {index}");

        var index = search.ExponentialSearch(numbers, 5);
        Console.WriteLine($"JumpSearch: {index}");

    }


}
