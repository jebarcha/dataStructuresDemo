using DataStructuresAndAlgorithms.MyArray;
using System.Collections;
using DataStructuresAndAlgorithms.Linked_List.DemoLL;
using DataStructuresAndAlgorithms.HashTables;
using DataStructuresAndAlgorithms.NonLinearStructures.BinaryTrees;
using DataStructuresAndAlgorithms.NonLinearStructures.AVLTree;
using DataStructuresAndAlgorithms.NonLinearStructures.Heap;
using DataStructuresAndAlgorithms.Queue;
using DataStructuresAndAlgorithms.NonLinearStructures.Tries;

#region Arrays
//DataStructuresAndAlgorithms.ArraysDemo1.ArraysExample();
//ArrayDemo();
//ArrayDynamicArray();


void ArrayDemo()
{
    var numbers = new MyArray(3);
    try
    {
        numbers.Insert(10);
        numbers.Insert(20);
        numbers.Insert(60);
        numbers.Insert(40);
        //numbers.Print();

        //Console.WriteLine("-----"); // Environment.NewLine);
        //numbers.RemoveAt(-1);
        //Console.WriteLine(numbers.IndexOf(20));
        //numbers.Print();
        //Console.WriteLine(numbers.LargestNumber());

        //var reverse = numbers.Reverse();
        //Utils.PrintString(reverse);

        //int[] newArr = { 10, 70, 60, 20 };
        //var intersect = numbers.CommonItems(newArr);
        //Utils.PrintString(intersect);

        numbers.InsertAt(4, 100);
        Console.WriteLine(numbers.IndexOf(100));
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message} {ex.StackTrace}");
    }
}
void ArrayDynamicArray()
{
    ArrayList list = new ArrayList();
    list.Add(10);
    list.Add(20);
    list.Add(30);
    list.Remove(30);
    //string.Join(",", list);
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }
}
#endregion

#region LinkedList
//LinkedListDemo1();
//MyLinkedList();

void LinkedListDemo1()
{
    DataStructuresAndAlgorithms.Linked_List.Demo1.Demo();
}
void MyLinkedList()
{
    var list = new LinkedList();
    //Console.WriteLine(list.Size());
    list.AddLast(10);
    list.AddLast(20);
    list.AddLast(30);
    //Console.WriteLine(list.Size());

    //list.AddFirst(5);
    //list.AddFirst(15);
    //Console.WriteLine(list.Size());

    //Console.WriteLine(list.IndexOf(10));
    //Console.WriteLine(list.IndexOf(30));
    //Console.WriteLine(list.IndexOf(400));

    //Console.WriteLine(list.Contains(400));
    //Console.WriteLine(list.Contains(10));

    //Console.WriteLine(list.Size());
    //list.RemoveFirst();
    //Console.WriteLine(list.Size());

    //Console.WriteLine(list.Size());
    //list.RemoveLast();
    //Console.WriteLine(list.Size());

    //convert liked list to an array:
    //Console.WriteLine(Utils.Array2String(list.ToArray()));

    //list.Reverse();
    //Console.WriteLine(Utils.Array2String(list.ToArray()));


    //list.AddLast(40);
    //list.AddLast(50);
    //Console.WriteLine(list.GetKthFromTheEnd(1));
    //Console.WriteLine(list.GetKthFromTheEnd(2));
    //Console.WriteLine(list.GetKthFromTheEnd(3));
    //Console.WriteLine(list.GetKthFromTheEnd(0));
    //Console.WriteLine(list.GetKthFromTheEnd(6));

    //list.PrintMiddle();
    //list.AddLast(60);
    //list.PrintMiddle();

    var listWithLoop = list.CreateWithLoop();
    Console.WriteLine(listWithLoop.HasLoop());

}

#endregion

#region Stacks
//CSharpStackDemo.Demo1();

////Console.WriteLine("String Reverser");
//var r = new StringReverser();
//var result = r.Reverse(null);
//Console.WriteLine(result);

////Console.WriteLine("Balanced Expression");
//var b = new BalancedExpression();
//var expression = "((1 + 2))";
//// Edge cases
//// expression = "("
//// expression = "(()"
//// ( ]
//// expression = ") ("
//var result = b.IsBalanced(expression);
//Console.WriteLine(result);

////Console.WriteLine("Stack");
//var stack = new DataStructuresAndAlgorithms.Stacks.Stack();
//Console.WriteLine(stack.IsEmpty());
//stack.Push(10);
//stack.Push(20);
//stack.Push(30);
//Console.WriteLine(stack);
////stack.Pop();
////Console.WriteLine(stack);
////Console.WriteLine(stack.Peek());
//Console.WriteLine(stack.IsEmpty());

////two stacks
//Console.WriteLine("Two Stacks");
//var twoStacks = new TwoStacks(6);
//Console.WriteLine(twoStacks.IsEmpty1());
//Console.WriteLine(twoStacks.IsEmpty2());
//twoStacks.Push1(10);
//twoStacks.Push1(20);
//twoStacks.Push1(30);
//twoStacks.Push1(50);
//Console.WriteLine(twoStacks.ToString());
//Console.WriteLine(twoStacks.IsEmpty1());
//Console.WriteLine(twoStacks.IsEmpty2());
//twoStacks.Push2(5);
//twoStacks.Push2(15);
//Console.WriteLine(twoStacks.IsEmpty1());
//Console.WriteLine(twoStacks.IsEmpty2());
//Console.WriteLine(twoStacks.ToString());

////min stack
//Console.WriteLine("Min Stack");
//var minStack = new MinStack();
//Console.WriteLine(minStack.ToString());
//minStack.Push(5);
//minStack.Push(2);
//minStack.Push(10);
//minStack.Push(1);
//Console.WriteLine(minStack.Min());
//minStack.Pop();
//Console.WriteLine(minStack.Min());

#endregion

#region Queues
//Console.WriteLine("C# Queue demo");
//CSharpQueueDemo.Demo();

//var q = new Queue<int>();
//q.Enqueue(10);
//q.Enqueue(20);
//q.Enqueue(30);
//CSharpQueueDemo.Reverse(q);

//CSharpQueueDemo.ArrayQueueDemo();

//CSharpQueueDemo.QueueWith2StacksDemo();

//CSharpQueueDemo.PriorityQueue();

//CSharpQueueDemo.MyPriorityQueue();
//CSharpQueueDemo.LinkedListQueue();

//CSharpQueueDemo.StackWithTwoQueues();

#endregion

#region #Hashtables

//Console.WriteLine("Hash Tables");
//CSharpHashTableDemo.Demo();
//CSharpHashTableDemo.FindFirstNonRepeatingCharacter();
//CSharpHashTableDemo.SetsDemo(); 
//CSharpHashTableDemo.FindFirstRepeatedCharecter();
//CSharpHashTableDemo.HashFunctionsDemo();
//CSharpHashTableDemo.HashTableDemo();

//CSharpHashTableDemo.MostFrequentDemo();
//CSharpHashTableDemo.CountPairsWithDiff();
//CSharpHashTableDemo.TwoSum();
//CSharpHashTableDemo.MyHashMapDemo();
#endregion

#region BinaryTrees
//Console.WriteLine("ALV Trees");
//AVLTreeDemo.MyAVLTree();

//Console.WriteLine("Binary Trees");
//TreesDemo.MyTree();

//Console.WriteLine(TreesDemo.Factorial(4));
//Console.WriteLine(TreesDemo.FactorialRecursion(3));
#endregion

#region Heaps
//Console.WriteLine("Heap Demo");
//MyHeapDemo.Demo();
#endregion

#region Tries
Console.WriteLine("Tries Demo");
MyTrieDemo.Demo();
#endregion

