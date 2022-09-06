using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataStructuresAndAlgorithms.NonLinearStructures.BinaryTrees.MyTree;

namespace DataStructuresAndAlgorithms.NonLinearStructures.BinaryTrees
{
    public static class TreesDemo
    {
        public static void MyTree()
        {
            // Equals(MyTree tree): bool

            MyTree tree = new MyTree();
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(10);

            //Console.WriteLine($"Height:{tree.Height()}");
            //Console.WriteLine($"Min:{tree.Min()}");

            //MyTree tree2 = new MyTree();
            //tree2.Insert(7);
            //tree2.Insert(4);
            //tree2.Insert(9);
            //tree2.Insert(1);
            //tree2.Insert(6);
            //tree2.Insert(8);
            //tree2.Insert(10);
            //Console.WriteLine($"tree.Equals: {tree.Equals(tree2)}");
            //Console.WriteLine($"tree.Equals: {tree.Equals(null)}");

            //tree.TraversePreOrder();
            //Console.WriteLine(tree.Find(10));
            //Console.WriteLine(tree.Find(11));

            //tree.SwapRoot(); //to mess up with the BST
            //Console.WriteLine($"IsBinarySearchTree: {tree.IsBinarySearchTree()}");

            //var result = tree.GetNodesAtDistance(2);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //tree.TraverseLevelOrder();

            #region MoreDemos
            //Console.WriteLine($"Size: {tree.Size()}");

            //Console.WriteLine($"Number of leaves: {tree.CountLeaves()}");

            //Console.WriteLine($"Maximum value: {tree.Max()}");

            //Console.WriteLine($"Contains 1: {tree.Contains(1)}");
            //Console.WriteLine($"Contains 11: {tree.Contains(11)}");

            //Console.WriteLine($"Are Siblings (1,2): {tree.AreSibling(1,2)}");
            //Console.WriteLine($"Are Siblings (4,9): {tree.AreSibling(4, 9)}");

            Console.WriteLine("GetAncestors of 6");
            var ancestors = tree.GetAncestors(6);
            foreach (var item in ancestors)
            {
                Console.WriteLine(item);
            }

            #endregion
        }

        public static int Factorial(int n)
        {
            // 4! = 4 x 3 x 2 x 1
            // 3! = 3 x 2 x 1
            var factorial = 1;
            for (int i = n; i > 1; i--)
            {
                factorial *= i;
            }
            return factorial;
        }
        public static int FactorialRecursion(int n)
        {
            if (n == 0) 
                return 1;

            return n * FactorialRecursion(n - 1);
        }
    }
}
