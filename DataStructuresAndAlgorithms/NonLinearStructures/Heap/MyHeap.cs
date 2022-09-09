using System;

namespace DataStructuresAndAlgorithms.NonLinearStructures.Heap;
public class MyHeap
{
    private int[] items = new int[10];
    private int size;

    public void Insert(int value)
    {
        if (IsFull())
        {
            throw new ArgumentOutOfRangeException();
        }

        items[size++] = value;

        BubbleUp();
    }

    public int Remove()
    {
        if (IsEmpty())
        {
            throw new ArgumentOutOfRangeException();
        }

        var root = items[0];
        items[0] = items[--size];

        // item (root) < children then Bubble Down
        BubbleDown();

        return root;
    }

    private void BubbleDown()
    {
        var index = 0;
        while (index <= size && !IsValidParent(index))
        {
            var largerChildIndex = LargerChildIndex(index);
            Swap(index, largerChildIndex);
            index = largerChildIndex;
        }
    }

    public bool IsEmpty() => size == 0;

    private int LargerChildIndex(int index)
    {
        if (!HasLeftChild(index))
        {
            return index;
        }
        if (!HasRightChild(index))
        {
            return LeftChildIndex(index);
        }

        return (LeftChild(index) > RightChild(index))
            ? LeftChildIndex(index)
            : RightChildIndex(index);
    }
    private bool HasLeftChild(int index) => LeftChildIndex(index) <= size;
    private bool HasRightChild(int index) => RightChildIndex(index) <= size;

    private bool IsValidParent(int index)
    {
        if (!HasLeftChild(index))
        {
            return true;
        }

        var isValid = items[index] >= LeftChild(index);

        if (HasRightChild(index))
        {
            isValid = isValid && items[index] >= RightChild(index);
        }

        return isValid;
    }


    private int LeftChild(int index) => items[LeftChildIndex(index)];
    private int LeftChildIndex(int index) => index * 2 + 1;
    private int RightChild(int index) => items[RightChildIndex(index)];
    private int RightChildIndex(int index) => index * 2 + 2;

    public bool IsFull() => size == items.Length;
    private void BubbleUp()
    {
        var index = size - 1;
        while (index > 0 && items[index] > items[Parent(index)])
        {
            Swap(index, Parent(index));
            index = Parent(index);
        }
    }
    private void Swap(int first, int second)
    {
        var temp = items[first];
        items[first] = items[second];
        items[second] = temp;
    }
    private int Parent(int index) => (index - 1) / 2;


    public int Max()
    {
        if (IsEmpty())
        {
            throw new ArgumentOutOfRangeException();
        }

        return items[0];
    }
}
