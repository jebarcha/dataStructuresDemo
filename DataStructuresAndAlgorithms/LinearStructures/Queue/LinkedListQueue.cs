using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Queue
{
    public class LinkedListQueue
    {
        private class Node
        {
            public int value;
            public Node next;

            public Node(int value)
            {
                this.value = value;
            }
        }

        private Node head;
        private Node tail;
        private int count;

        // O(1)
        public void Enqueue(int item)
        {
            var node = new Node(item);

            if (IsEmpty())
                head = tail = node;
            else
            {
                tail.next = node;
                tail = node;
            }

            count++;
        }

        // O(1)
        public int Dequeue()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException();

            int value;
            if (head == tail)
            {
                value = head.value;
                head = tail = null;
            }
            else
            {
                value = head.value;
                var second = head.next;
                head.next = null;
                head = second;
            }

            count--;

            return value;
        }

        // O(1)
        public int Peek()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException();

            return head.value;
        }

        // O(1)
        public int Size()
        {
            return count;
        }

        // O(1)
        public bool IsEmpty()
        {
            return head == null;
        }

        // O(n)
        public override string ToString()
        {
            List<int> list = new List<int>();
            //ArrayList<Integer> list = new ArrayList<>();

            Node current = head;
            while (current != null)
            {
                list.Add(current.value);
                current = current.next;
            }

            return DataUtils.Utils.Array2String(list);
        }

    }
}
