using System;

namespace DataStructuresAndAlgorithms.NonLinearStructures.Heap;

public class MinHeap
{
    private class Node
    {
        public int key;
        public string value;

        public Node(int key, String value)
        {
            this.key = key;
            this.value = value;
        }
    }

    private Node[] nodes = new Node[10];
    private int size;

    public void Insert(int key, String value)
    {
        if (IsFull())
            throw new ArgumentOutOfRangeException();

        nodes[size++] = new Node(key, value);

        BubbleUp();
    }

    public string Remove()
    {
        if (IsEmpty())
            throw new ArgumentOutOfRangeException();

        var root = nodes[0].value;
        nodes[0] = nodes[--size];

        BubbleDown();

        return root;
    }

    private void BubbleDown()
    {
        var index = 0;
        while (index <= size && !IsValidParent(index))
        {
            var largerChildIndex = SmallerChildIndex(index);
            Swap(index, largerChildIndex);
            index = largerChildIndex;
        }
    }

    public bool IsEmpty() => size == 0;

    private int SmallerChildIndex(int index)
    {
        if (!HasLeftChild(index))
            return index;

        if (!HasRightChild(index))
            return LeftChildIndex(index);

        return (LeftChild(index).key < RightChild(index).key) ?
                LeftChildIndex(index) :
                RightChildIndex(index);
    }

    private bool HasLeftChild(int index) => LeftChildIndex(index) <= size;

    private bool HasRightChild(int index) => RightChildIndex(index) <= size;

    private bool IsValidParent(int index)
    {
        if (!HasLeftChild(index))
            return true;

        var isValid = nodes[index].key <= LeftChild(index).key;

        if (HasRightChild(index))
            isValid &= nodes[index].key <= RightChild(index).key;

        return isValid;
    }

    private Node RightChild(int index) => nodes[RightChildIndex(index)];

    private Node LeftChild(int index) => nodes[LeftChildIndex(index)];

    private int LeftChildIndex(int index) => index * 2 + 1;

    private int RightChildIndex(int index) => index * 2 + 2;

    public bool IsFull() => size == nodes.Length;

    private void BubbleUp()
    {
        var index = size - 1;
        while (index > 0 && nodes[index].key < nodes[Parent(index)].key)
        {
            Swap(index, Parent(index));
            index = Parent(index);
        }
    }

    private int Parent(int index) => (index - 1) / 2;

    private void Swap(int first, int second)
    {
        var temp = nodes[first];
        nodes[first] = nodes[second];
        nodes[second] = temp;
    }
}
