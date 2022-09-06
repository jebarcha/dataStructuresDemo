using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.HashTables
{
    public class MyHashTable
    {
        private class Entry
        {
            public int key;
            public string value;
            public Entry(int key, string value)
            {
                this.key = key;
                this.value = value;
            }
        }

        private LinkedList<Entry>[] entries = new LinkedList<Entry>[5];

        public void Put(int key, string value)
        {
            var entry = GetEntry(key);
            if (entry != null)
            {
                entry.value = value;
                return;
            }

            GetOrCreateBucket(key).AddLast(new Entry(key, value));
        }

        public string Get(int key)
        {
            var entry = GetEntry(key);
            return entry == null ? null : entry.value;

            //var index = Hash(key);
            //var bucket = entries[index];
            //if (bucket != null)
            //{
            //    foreach (var entry in bucket)
            //    {
            //        if (entry.key == key)
            //        {
            //            return entry.value;
            //        }
            //    }
            //}
            //return null;
        }
        public void Remove(int key)
        {
            var entry = GetEntry(key);
            if (entry == null)
                throw new ArgumentOutOfRangeException();

            GetBucket(key).Remove(entry);

            //var index = Hash(key);
            //var bucket = entries[index];
            //if (bucket == null)
            //{
            //    throw new ArgumentOutOfRangeException();
            //}
            //foreach (var entry in bucket)
            //{
            //    if (entry.key == key)
            //    {
            //        bucket.Remove(entry);
            //        return;
            //    }
            //}
            //throw new ArgumentOutOfRangeException();
        }
        private LinkedList<Entry> GetBucket(int key)
        {
            return entries[Hash(key)];
            //var index = Hash(key);
            //var bucket = entries[index];
            //return bucket;
        }
        private LinkedList<Entry> GetOrCreateBucket(int key)
        {
            var index = Hash(key);
            var bucket = entries[index];
            if (bucket == null)
            {
                entries[index] = new LinkedList<Entry>();
            }
            return bucket;
        }
        private Entry GetEntry(int key)
        {
            //var index = Hash(key);
            //var bucket = entries[index];
            var bucket = GetBucket(key);
            if (bucket != null)
            {
                foreach (var entry in bucket)
                {
                    if (entry.key == key)
                    {
                        return entry;
                    }
                }
            }
            return null;
        }
        private int Hash(int key) => key % entries.Length;
        
    }
}
