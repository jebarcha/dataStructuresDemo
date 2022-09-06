using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Queue
{
    public class QueueReverser
    {
        public void Reverse(Queue<int> queue, int k)
        {
            if (k < 0 || k > queue.Count)
                throw new ArgumentOutOfRangeException();

            Stack<int> stack = new Stack<int>();

            // Dequeue the first K elements from the queue
            // and push them onto the stack
            for (int i = 0; i < k; i++)
                stack.Push(queue.Dequeue());

            // Enqueue the content of the stack at the
            // back of the queue
            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());

            // Add the remaining items in the queue (items
            // after the first K elements) to the back of the
            // queue and remove them from the beginning of the queue
            for (int i = 0; i < queue.Count - k; i++)
                queue.Enqueue(queue.Dequeue());
        }
    }
}
