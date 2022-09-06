using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Stacks
{
    public class StringReverser
    {
        public string Reverse(string input)
        {
            if (input is null) throw new ArgumentException("null not allowed");

            var stack = new Stack<char>();

            foreach (var letter in input)
            {
                stack.Push(letter);
            }

            StringBuilder reversed = new StringBuilder();
            while (stack.Count > 0)
            {
                reversed.Append(stack.Pop());
            }

            return reversed.ToString();
        }
    }
}
