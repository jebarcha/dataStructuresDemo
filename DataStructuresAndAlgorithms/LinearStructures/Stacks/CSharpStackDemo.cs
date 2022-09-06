using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Stacks
{
    public static class CSharpStackDemo
    {
        public static void Demo1()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            foreach (var item in stack)
                Console.WriteLine(item);

            var top = stack.Pop();
            Console.WriteLine("\b");
            Console.WriteLine(top);

            Console.WriteLine("\b");
            foreach (var item in stack)
                Console.WriteLine(item);

            var topPeek = stack.Peek();
            Console.WriteLine("\b");
            Console.WriteLine(topPeek);

            Console.WriteLine("\b");
            foreach (var item in stack)
                Console.WriteLine(item);

        }
    }
}
