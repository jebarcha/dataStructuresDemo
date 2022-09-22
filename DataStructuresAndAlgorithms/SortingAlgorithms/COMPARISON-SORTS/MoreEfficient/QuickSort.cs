namespace DataStructuresAndAlgorithms.SortingAlgorithms.MoreEfficient;
public class QuickSort
{
    public void Sort(int[] array)
    {
        Sort(array, 0, array.Length - 1);
    }

    // e.g.:
    // 0, 9 array of 10 items
    // 4 pivot
    // 0, 3 left
    // 5, 9 right
    private void Sort(int[] array, int start, int end)
    {
        // base condition
        if (start >= end)
            return;

        var boundary = Partition(array, start, end);

        // Sort left
        Sort(array, start, boundary - 1);

        // Sort right
        Sort(array, boundary + 1, end);
    }

    private int Partition(int[] array, int start, int end)
    {
        var pivot = array[end];
        var boundary = start - 1;
        for (int i = start; i <= end; i++)
        {
            if (array[i] <= pivot)
                Swap(array, i, ++boundary);
        }

        return boundary;

    }
    private void Swap(int[] array, int index1, int index2)
    {
        var temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }

}
