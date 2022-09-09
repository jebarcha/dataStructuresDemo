using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Queue
{
    public static class CSharpQueueDemo
    {
        public static void Demo()
        {
            Queue<int> q = new Queue<int>();

            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);
            q.Dequeue();

            Console.WriteLine(DataStructuresAndAlgorithms.DataUtils.Utils.Array2String(q.ToArray()));
        }
        public static void Reverse(Queue<int> queue)
        {
            // add
            // remove
            // isEmpty
            // Q [10,20,30]
            // S [10, 20, 30]
            Stack<int> stack = new Stack<int>();
            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
            Console.WriteLine(DataStructuresAndAlgorithms.DataUtils.Utils.Array2String(queue.ToArray()));
        }

        public static void ArrayQueueDemo()
        {
            var queue = new ArrayQueue(5);
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            //Console.WriteLine(queue.ToString());
            //var front = queue.Dequeue();
            //Console.WriteLine(front);
            //Console.WriteLine(queue.ToString());

            //front = queue.Dequeue();
            ////Console.WriteLine(front);
            //Console.WriteLine(queue.ToString());

            queue.Enqueue(40);
            queue.Enqueue(50);
            //Console.WriteLine(queue.ToString());

            //queue.Enqueue(60);
            //Console.WriteLine(queue.ToString());

            //queue.Enqueue(70);
            //Console.WriteLine(queue.ToString());

            //queue.Dequeue();
            //Console.WriteLine(queue.ToString());

            //queue.Enqueue(80);
            Console.WriteLine(queue.ToString());

            Console.WriteLine($"Peek: {queue.Peek()}");

            Console.WriteLine($"IsEmpty: {queue.IsEmpty()}");

            Console.WriteLine($"IsFull: {queue.IsFull()}" );
        }

        public static void QueueWith2StacksDemo()
        {
            QueueWithTwoStacks queue = new QueueWithTwoStacks();
            Console.WriteLine(queue.IsEmpty());
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Dequeue();
            var first = queue.Dequeue();
            Console.WriteLine(first);
            Console.WriteLine(queue.Peek());
        }

        public static void PriorityQueue()
        {
            PriorityQueue<int, int> p = new PriorityQueue<int, int>();
            p.Enqueue(5, 5);
            p.Enqueue(1, 1);
            p.Enqueue(3, 3);
            p.Enqueue(2, 2);
            while (p.Count> 0)
            {
                Console.WriteLine(p.Dequeue());
            }
        }
        public static void MyPriorityQueue()
        {
            var q = new MyPriorityQueue();
            q.Add(5);
            q.Add(3);
            q.Add(6);
            q.Add(1);
            q.Add(4);
            Console.WriteLine(q.ToString());

            while (!q.IsEmpty())
            {
                Console.WriteLine(q.Remove());
            }

        }
        public static void LinkedListQueue()
        {
            var q = new LinkedListQueue();
            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);
            q.Enqueue(40);
            q.Enqueue(50);
            Console.WriteLine(q.ToString());

            int dequeued = q.Dequeue();
            Console.WriteLine(dequeued);
            Console.WriteLine(q.ToString());

            int resPeeked = q.Peek();
            Console.WriteLine(resPeeked);
            Console.WriteLine(q.ToString());
        }

        public static void StackWithTwoQueues()
        {
            var s = new StackWithTwoQueues();
            s.Push(10);
            s.Push(20);
            s.Push(30);
            Console.WriteLine(s.ToString());

            var pop = s.Pop();
            Console.WriteLine(pop);
            Console.WriteLine(s.ToString());

            var peek = s.Peek();
            Console.WriteLine(peek);
            Console.WriteLine(s.Size());
            Console.WriteLine(s.ToString());


        }
    }
}




