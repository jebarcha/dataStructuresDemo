using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Queue
{
    public class QueueWithTwoStacks
    {
        // Q [10, 20, 30]  /dequeue 10
        // S1 []  //old:[10, 20, 30]           use it for the enqueue
        // S2 [30,20,10]  //reverse the 1st stack, pop 10  // dequeue
        // whenever the S2 is empty, we need to move all items in S1 to S2

        private Stack<int> _stack1 = new Stack<int>();
        private Stack<int> _stack2 = new Stack<int>();
        public void Enqueue(int item)
        {
            // The run time complexity of enqueu is O(1)
            _stack1.Push(item);
        }
        public int Dequeue()
        {
            // The run time complexity of enqueu is O(n)
            if (IsEmpty())
                throw new ArgumentOutOfRangeException();

            MoveStack1ToStack2();

            return _stack2.Pop();
        }
        public int Peek()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException();

            MoveStack1ToStack2();

            return _stack2.Peek();
        }
        private void MoveStack1ToStack2()
        {
            if (_stack2.Count == 0)
            {
                while (_stack1.Count > 0)
                {
                    _stack2.Push(_stack1.Pop());
                }
            }
        }
        public bool IsEmpty()
        {
            return _stack1.Count == 0 && _stack2.Count == 0;
        }
    }
}
