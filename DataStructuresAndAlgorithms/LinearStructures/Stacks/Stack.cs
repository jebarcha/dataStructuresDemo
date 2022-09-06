using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Stacks
{
    public class Stack
    {
        private int[] _items = new int[5];
        private int _count;
        public void Push(int item)
        {
            if (_count == _items.Length) 
                throw new StackOverflowException();

            _items[_count++] = item;
        }
        public int Pop()
        {
            if (_count == 0) 
                throw new InvalidOperationException();

            return _items[_count--];
        }
        public int Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException();

            return _items[_count - 1];
        }
        public bool IsEmpty() => _count == 0;

        public override string ToString()
        {
            var content = new int[_count];
            Array.Copy(_items, 0, content, 0, _count);
            return DataUtils.Utils.Array2String(content);
        }


    }


}
