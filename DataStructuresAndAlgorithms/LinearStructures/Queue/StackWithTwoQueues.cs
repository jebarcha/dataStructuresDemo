using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Queue
{
    // We always use queue1 for pushing new items.
    // When popping an item, we move all the items
    // except the last one from queue1 to queue2.
    //
    // Q1 [10, 20, 30, 40] => Q1 [40]
    // Q2 []               => Q2 [10, 20, 30]
    //
    // Now the item to be popped is in Q1. We remove
    // and return that as the item on top of the stack.
    //
    // Q1 []
    // Q2 [10, 20, 30]
    //
    // We should swap the queues, so we can repeat this
    // algorithm next time we need to pop the stack.
    //
    // Q1 [10, 20, 30]
    // Q2 []  (ready for moving items)

    public class StackWithTwoQueues
    {
        private Queue<int> queue1 = new Queue<int>();
        private Queue<int> queue2 = new Queue<int>();
        private int top;

        // O(1)
        public void Push(int item)
        {
            queue1.Enqueue(item);
            top = item;
        }

        // O(n)
        public int Pop()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException();

            while (queue1.Count > 1)
            {
                top = queue1.Dequeue();
                queue2.Enqueue(top);
            }

            SwapQueues();

            return queue2.Dequeue();
        }

        private void SwapQueues()
        {
            var temp = queue1;
            queue1 = queue2;
            queue2 = temp;
        }

        // O(1)
        public bool IsEmpty()
        {
            return queue1.Count == 0;
        }

        // O(1)
        public int Size()
        {
            return queue1.Count();
        }

        // O(1)
        public int Peek()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException();

            return top;
        }

        public override string ToString()
        {
            return DataUtils.Utils.Array2String(queue1);
        }

    }
}
