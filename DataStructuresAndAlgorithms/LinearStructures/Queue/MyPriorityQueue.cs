using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Queue
{
    public class MyPriorityQueue
    {
        private int[] _items = new int[5];
        private int _count;
        public void add(int item)
        {
            if (IsFull())
                throw new ArgumentOutOfRangeException();

            int i = ShiftItemsToInsert(item);
            _items[i] = item;
            _count++;
        }
        public int ShiftItemsToInsert(int item)
        {
            int i;
            for (i = _count - 1; i >= 0; i--)
            {
                if (_items[i] > item)
                {
                    _items[i + 1] = _items[i];
                }
                else
                {
                    break;
                }
            }
            return i + 1;
        }
        public int Remove()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException();
            
            return _items[--_count];
        }
        public bool IsFull() => _count == _items.Length;
        public bool IsEmpty() => _count == 0;

        public override string ToString()
        {
            return DataUtils.Utils.Array2String(_items);
        }
    }
}

