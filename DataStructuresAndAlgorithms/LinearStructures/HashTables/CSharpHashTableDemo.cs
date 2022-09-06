using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.HashTables
{
    public static class CSharpHashTableDemo
    {
        public static void Demo()
        {
            //Dictionary<int, string> hashTable = new Dictionary<int, string>();
            //HashSet<string> keys = new HashSet<string>();
            Hashtable ht = new Hashtable();
            ht.Add(1, "Jose");
            ht.Add(2, "Juan");
            ht.Add(3, "Luis");
            //ht.Add(4, null);  // allowed
            //ht.Add(null, null); // not allowed
            ht.Add(4, "Joe");
            //ht.Add(4, "Mary");
            
            ht.Remove(3);

            //ht[1] = "Jose de Jesus";
            Console.WriteLine(ht[1]);

            Console.WriteLine(ht.ContainsKey(4));  //O(1)
            Console.WriteLine(ht.ContainsValue("Joe"));  //O(n)


            //ICollection key = ht.Keys;
            //foreach (int k in key)
            //{
            //    Console.WriteLine(k + ": " + ht[k]);
            //}
            Console.WriteLine("\n");
            foreach (DictionaryEntry entry in ht)
            {
                Console.WriteLine("{0}: {1}", entry.Key, entry.Value);
            }

        }
        public static void FindFirstNonRepeatingCharacter()
        {
            // a green apple
            var charFinder = new CharFinder();
            var result = charFinder.FindFistNonRepeatingChar("a green apple");
            Console.WriteLine(result);
        }

        public static void SetsDemo()
        {
            HashSet<int> set = new HashSet<int>();
            int[] numbers = { 1, 2, 3, 3, 2, 1, 4 };
            foreach (var number in numbers)
            {
                set.Add(number);
            }
            foreach (var item in set)
                Console.WriteLine(item);
        }

        public static void FindFirstRepeatedCharecter()
        {
            // green apple
            var charFinder = new CharFinder();
            var result = charFinder.FindFirstRepeatedChar("green apple");
            Console.WriteLine(result);
        }

        public static void HashFunctionsDemo()
        {
            string str = "orange";
            Console.WriteLine(str.GetHashCode()); //hashing

            //Hashtable map = new Hashtable();
            //map.Add(123456, "Jose");
            //Console.WriteLine(Hash(123456));
            //Console.WriteLine(HashString("123456-A"));
        }
        public static int Hash(int number)
        {
            return number % 100;  //assumming that 100 is the size if our internal array
        }
        public static int HashString(string key)
        {
            //string s = "";
            //Console.WriteLine(s.GetHashCode());

            int hash = 0;
            foreach (var ch in key) 
            {
                hash += ch;
            }
            return hash % 100;
        }

        public static void HashTableDemo()
        {
            MyHashTable table = new MyHashTable();
            table.Put(6, "A");  //1
            table.Put(8, "B");  //3
            table.Put(11, "C");
            table.Put(6, "A+");
            //Console.WriteLine(table.Get(6));
            table.Remove(6);
            Console.WriteLine(table.Get(10));


        }

        public static void MostFrequentDemo()
        {
            var ht = new HashTableExercises();
            int[] n = new int[] { 1, 2, 2, 3, 3, 3, 4 };
            Console.WriteLine(ht.MostFrequent(n));
        }
        public static void CountPairsWithDiff()
        {
            var ht = new HashTableExercises();
            int[] n = new int[] { 1, 7, 5, 9, 2, 12, 3 };
            Console.WriteLine(ht.CountPairsWithDiff(n, 2));
        }

        public static void TwoSum()
        {
            var ht = new HashTableExercises();
            int[] n = new int[] { 2, 7, 11, 15 };
            var result = ht.TwoSum(n, 9);
            Console.WriteLine(DataUtils.Utils.Array2String(result));
        }

        public static void MyHashMapDemo()
        {
            var map = new MyHashMap();
            map.Put(1, "A");
            map.Put(2, "B");
            map.Put(3, "C");
            Console.WriteLine(map.Get(2));
            map.Remove(3);
            Console.WriteLine(map.Size());

        }
    }
}

