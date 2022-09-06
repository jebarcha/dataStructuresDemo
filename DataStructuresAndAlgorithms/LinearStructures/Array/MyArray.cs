using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.MyArray
{
    public class MyArray
    {
        private int[] _items;
        private int _count;
        public MyArray(int length)
        {
            _items = new int[length];
            _count = 0;
        }
        public void Insert(int item)
        {
            // If the array is full, resize it
            if (_items.Length == _count)
            {
                IncreaseArrayLength(_count * 2);
            }
            // Add the new item at the end
            _items[_count++] = item;
        }
        private void IncreaseArrayLength(int lenght)
        {
            // Create a new array (twice the size)
            int[] newItems = new int[lenght];

            // Copy all the existint items
            for (int i = 0; i < _count; i++)
            {
                newItems[i] = _items[i];
            }

            // Set "items" to this new array
            _items = newItems;
        }
        public void RemoveAt(int index)
        {
            // Validate the index
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            // Shift the items to the left to fill the hole
            // [10, 20 ,30, 40]
            // index: 1
            for (int i = index; i < _count; i++)
            {
                _items[i] = _items[i + 1];
            }
            _count--;

        }
        public int IndexOf(int item)
        {
            // If we find it, return index
            // Otherwise, return -1
            for (int i = 0; i < _count; i++)
            {
                if (_items[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Print()
        {
            //Action<int> action = new Action<int>(DataUtils.Utils.Print);
            //Array.ForEach(_items, action);
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(_items[i]);
            }
        }
        public int LargestNumber()
        {
            return _items.Max();
        }
        public IEnumerable<int> CommonItems(int[] array)
        {
            return _items.Intersect(array);
        }
        public IEnumerable<int> Reverse()
        {
            int[] reverse = new int[_count];
            int index = 0;
            for (int i = _count-1; i >= 0; i--)
            {
                reverse[index++] = _items[i];
            }
            return reverse;
        }
        public void InsertAt(int index, int item)
        {
            if (_items.Length == _count)
            {
                IncreaseArrayLength(index);
            }

            if (_items[index] == 0)
            {
                _items[index] = item;
            }
            _count++;
            //else
            //{
            //    // 10, 20, 30, 40
            //    //         60
            //    // 10, 20, 60, 30, 40
            //    for (int i = index; i < _count; i++)
            //    {
            //        int value = _items[i];
            //        _items[i] = item;

            //    }
            //}
        }
    }
}
