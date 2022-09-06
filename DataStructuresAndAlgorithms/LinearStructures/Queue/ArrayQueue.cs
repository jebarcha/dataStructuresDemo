using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Queue
{
    public class ArrayQueue
    {
        #region analysis
        // Enqueue
        // Dequeue
        // Peek
        // IsEmpty
        // IsFull

        // [10, 20, 30, 40, 0]
        //   F           R
        // F=0
        // R=3

        // [10, 20, 30, 40, 0]
        //      F           R
        // F=1
        // R=4

        //Circular array analysis
        // [60, 70, 30, 40, 50]
        // -> means "is map to"
        // 5  -> 0  Left % Length
        // 6  -> 1
        // 7  -> 2
        // 8  -> 3
        // 9  -> 4
        // 10 -> 0
        // 11 -> 1
        // rear + 1 (will give us the number of the left side and then should map it to the number of the right side)
        // (rear + 1) % length
        #endregion

        private int[] _items = new int[5];
        private int _rear;
        private int _front;
        private int _count;
        public ArrayQueue(int capacity)
        {
            _items = new int[capacity];
        }

        public void Enqueue(int item)
        {
            if (_count == _items.Length) 
                throw new ArgumentOutOfRangeException();
            
            _items[_rear] = item;
            _rear = (_rear + 1) % _items.Length;
            _count++;
        }
        public int Dequeue()
        {
            var item = _items[_front];
            _items[_front] = 0;
            _front = (_front + 1) % _items.Length;
            _count--;
            return item;
        }
        public int Peek()
        {
            if (IsEmpty()) 
                throw new ArgumentOutOfRangeException();
            
            return _items[_front];
        }

        public bool IsEmpty() => _count == 0;
        public bool IsFull() => _count == _items.Length;
        public override string ToString()
        {
            return DataUtils.Utils.Array2String(_items);
        }



    }
}
