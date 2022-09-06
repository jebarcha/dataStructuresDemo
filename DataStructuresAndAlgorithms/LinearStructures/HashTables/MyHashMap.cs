using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.HashTables
{
    public class MyHashMap
    {
        private class Entry
        {
            public int key;
            public String value;

            public Entry(int key, String value)
            {
                this.key = key;
                this.value = value;
            }

            public override string ToString()
            {
                return value;
            }
        }

        private Entry[] entries = new Entry[5];
        private int count;

        public void Put(int key, String value)
        {
            var entry = GetEntry(key);
            if (entry != null)
            {
                entry.value = value;
                return;
            }

            if (IsFull())
                throw new ArgumentOutOfRangeException();

            entries[GetIndex(key)] = new Entry(key, value);
            count++;
        }

        public String Get(int key)
        {
            var entry = GetEntry(key);
            return entry != null ? entry.value : null;
        }

        public void Remove(int key)
        {
            var index = GetIndex(key);
            if (index == -1 || entries[index] == null)
                return;

            entries[index] = null;
            count--;
        }

        public int Size()
        {
            return count;
        }

        private Entry GetEntry(int key)
        {
            var index = GetIndex(key);
            return index >= 0 ? entries[index] : null;
        }

        private int GetIndex(int key)
        {
            int steps = 0;

            // Linear probing algorithm: we keep looking until we find an empty
            // slot or a slot with the same key.

            // We use this loop conditional to prevent an infinite loop that
            // will happen if the array is full and we keep probing with no
            // success. So, the number of steps (or probing attempts) should
            // be less than the size of our table.
            while (steps < entries.Length)
            {
                int index = Index(key, steps++);
                var entry = entries[index];
                if (entry == null || entry.key == key)
                    return index;
            }

            // This will happen if we looked at every slot in the array
            // and couldn't find a place for this key. That basically means
            // the table is full.
            return -1;
        }

        private bool IsFull()
        {
            return count == entries.Length;
        }

        private int Index(int key, int i)
        {
            return (Hash(key) + i) % entries.Length;
        }

        private int Hash(int key)
        {
            return key % entries.Length;
        }

        public override string ToString()
        {
            return DataUtils.Utils.Array2String(entries);
            //return Arrays.ToString(entries);
        }

    }
}
