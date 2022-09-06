using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.HashTables
{
    public class CharFinder
    {
        public char FindFistNonRepeatingChar(string str)
        {
            Hashtable map = new Hashtable();

            foreach (var ch in str)
            {
                if (map.ContainsKey(ch))
                {
                    map[ch] = (int)map[ch] + 1;
                } 
                else
                {
                    map.Add(ch, 1);
                }
                //var count = map.ContainsKey(ch) ? map[ch] : 0;
            }

            foreach (var ch in str)
            {
                if ((int)map[ch] == 1)
                {
                    return ch;
                }
            }

            //foreach (DictionaryEntry entry in map)
            //    Console.WriteLine("{0}: {1}", entry.Key, entry.Value);

            return char.MinValue; // '0';
        }


        public char FindFirstRepeatedChar(string str)
        {
            HashSet<char> set = new HashSet<char>();

            foreach (var ch in str)
            {
                if (set.Contains(ch))
                {
                    return ch;
                }
                set.Add(ch);
            }
            return char.MinValue;
        }
    }
}
