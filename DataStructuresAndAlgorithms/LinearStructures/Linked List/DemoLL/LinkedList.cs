using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Linked_List.DemoLL
{
    public class LinkedList
    {
        private class Node
        {
            public int _value;
            public Node _next;
            public Node(int value)
            {
                _value = value;
            }
        }

        private Node _first;
        private Node _last;
        private int _size;

        public void AddFirst(int item)
        {
            var node = new Node(item);
            
            if (IsEmpty())
            {
                _first = _last = node;
            }
            else
            {
                node._next = _first;
                _first = node;
            }
            _size++;
        }
        public void AddLast(int item)
        {
            var node = new Node(item);

            if (IsEmpty())
            {
                _first = _last = node;
            }
            else
            {
                _last._next = node;
                _last = node;
            }
            _size++;
        }
        private bool IsEmpty() => _first == null;
        public int IndexOf(int item)
        {
            int index = 0;
            var current = _first;
            while (current != null)
            {
                if (current._value == item)
                {
                    return index;
                }
                current = current._next;
                index++;
            }
            return -1;
        }
        public bool Contains(int item) => IndexOf(item) != -1;
        public void RemoveFirst()
        {
            // [10 -> 20 -> 30]
            // first -> 20
            if (IsEmpty())
            {
                throw new ArgumentOutOfRangeException();
            }

            if (HasASingleNode())
            {
                _first = _last = null;
            }
            else
            {
                var second = _first._next;
                _first._next = null;
                _first = second;
            }

            _size--;
        }
        public void RemoveLast()
        {
            // [10 -> 20 -> 30]
            // previous -> 20
            // last -> 30  (we need to change last to point to previous, so: [10 -> 20])

            if (IsEmpty())
            {
                throw new ArgumentOutOfRangeException();
            }

            if (HasASingleNode())
            {
                _first = _last = null;
            }
            else
            {
                var previous = GetPrevious(_last);
                _last = previous;
                _last._next = null;
            }

            _size--;
        }
        private bool HasASingleNode() => _first == _last;
        private Node GetPrevious(Node node)
        {
            var current = _first;
            while (current != null)
            {
                if (current._next == node) return current;
                current = current._next;
            }
            return null;
        }
        public int Size() => _size;
        public int[] ToArray()
        {
            int[] array = new int[_size];
            var current = _first;
            var index = 0;
            while (current != null) {
                array[index++] = current._value;
                current = current._next;
            }

            return array;
        }
        public void Reverse()
        {
            // Reversing the linked list:
            // [10 -> 20 -> 30]
            // [10 <- 20 <- 30]
            //  p     c     n
            //  n = c.next
            //  c.next = p
            // instead of 20 referencing 30, it will reference 10

            if (IsEmpty()) return;

            var previous = _first;
            var current = _first._next;
            while (current != null)
            {
                var next = current._next;
                current._next = previous;
                previous = current;
                current = next;
            }

            _last = _first;
            _last._next = null;
            _first = previous;
        }
        public int GetKthFromTheEnd(int k)
        {
            // Find the Kth node from the end
            // of a linked list in one pass.
            // [10 -> 20 -> 30 -> 40 -> 50]
            // k = 1 (50)
            // k = 2 (40)
            // k = 3 (30)

            if (IsEmpty()) throw new InvalidOperationException();

            var a = _first;
            var b = _first;
            for (int i = 0; i < k - 1; i++)
            {
                b = b._next;
                if (b == null) throw new ArgumentOutOfRangeException();
            }
            while (b != _last)
            {
                a = a._next;
                b = b._next;
            }
            return a._value;
        }
        public void PrintMiddle()
        {
            if (IsEmpty()) throw new InvalidOperationException();

            var a = _first;
            var b = _first;
            while (b != _last && b._next != _last)
            {
                b = b._next._next;
                a = a._next;
            }

            if (b == _last)
            {
                Console.WriteLine(a._value);
            }
            else
            {
                Console.WriteLine($"{a._value}, {a._next._value}");
            }
        }
        public bool HasLoop()
        {
            if (IsEmpty()) throw new InvalidOperationException();

            var slow = _first;
            var fast = _first;
            while (fast != null && fast._next != _last)
            {
                slow = slow._next;
                fast = fast._next._next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }

        public LinkedList CreateWithLoop()
        {
            var list = new LinkedList();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            // Get a reference to 30
            var node = list._last;

            list.AddLast(40);
            list.AddLast(50);

            // Create the loop
            list._last._next = node;

            return list;
        }
    }
}
