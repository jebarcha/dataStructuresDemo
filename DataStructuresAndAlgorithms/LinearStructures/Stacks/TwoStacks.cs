using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Stacks
{
    // Implement two stacks in one array.
    // Make sure your implementation is space efficient.
    // (hint: do not allocate the same amount of space by dividing the array in half.)  
    public class TwoStacks
    {
        private int _top1;
        private int _top2;
        private int[] _items;

        public TwoStacks(int capacity)
        {
            if (capacity <= 0)
                throw new InvalidOperationException("capacity must be 1 or greater.");

            _items = new int[capacity];
            _top1 = -1;
            _top2 = capacity;
        }

        public void Push1(int item)
        {
            if (IsFull1())
                throw new InvalidOperationException();

            _items[++_top1] = item;
        }

        public int Pop1()
        {
            if (IsEmpty1())
                throw new InvalidOperationException();

            return _items[_top1--];
        }

        public bool IsEmpty1()
        {
            return _top1 == -1;
        }

        public bool IsFull1()
        {
            return _top1 + 1 == _top2;
        }

        public void Push2(int item)
        {
            if (IsFull2())
                throw new InvalidOperationException();

            _items[--_top2] = item;
        }

        public int Pop2()
        {
            if (IsEmpty2())
                throw new InvalidOperationException();

            return _items[_top2++];
        }

        public bool IsEmpty2()
        {
            return _top2 == _items.Length;
        }
        public bool IsFull2()
        {
            return _top2 - 1 == _top1;
        }

        public override String ToString()
        {
            return DataUtils.Utils.Array2String(_items);
        }
    }
}
