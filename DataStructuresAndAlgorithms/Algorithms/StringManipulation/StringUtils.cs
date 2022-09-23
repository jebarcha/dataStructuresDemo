using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;

namespace DataStructuresAndAlgorithms.Algorithms.StringManipulation;
public static class StringUtils
{
    
    public static int NumberOfVowels(string str)
    {
        if (str is null)
            return 0;

        int count = 0;

        foreach (var ch in str.ToLower())
        {
            if ("aeiou".Contains(ch))
                count++;
        }

        return count;
    }

    public static string ReverseString(string str)
    {
        if (str is null)
            return String.Empty;

        //BAD
        //string result2 = String.Empty;
        //for (int i = str.Length - 1; i >= 0; i--)
        //    result2 += str[i];
        //Console.WriteLine($"result2: {result2}");

        //BETTER
        //var reversed = str.Reverse();
        //string result = string.Empty;
        //foreach (var ch in reversed)
        //    result += ch;      

        //BEST
        StringBuilder reversed = new StringBuilder();
        foreach (var ch in str.Reverse())  //(O(n)
            reversed.Append(ch);  //O(1)

        return reversed.ToString();
    }

    public static string ReverseWords(string words)
    {
        if (words is null)
            return String.Empty;

        // GOOD
        //var reversedWords2 = words.Split(' ');
        //StringBuilder reversed = new StringBuilder();
        //for (int i = reversedWords2.Length - 1; i >= 0; i--)
        //    reversed.Append(reversedWords2[i] + " ");
        //return reversed.ToString().Trim();

        //BEST
        var reversedWords = words.Trim().Split(' ').Reverse();
        var reversed = String.Join(" ", reversedWords);
        return reversed;
    }

    public static bool AreRotations(string str1, string str2)
    {
        if (str1 is null || str2 is null)
            return false;

        // ABCD -> DABC
        //      -> CDAB
        //      -> BCDA
        //      -> ABCD

        return (str1.Length == str2.Length && (str1 + str1).Contains(str2));

        //if (str1.Length != str2.Length)
        //    return false;

        //if (!(str1 + str1).Contains(str2))
        //    return false;

        //return true;
    }

    public static string RemoveDuplicateCharacters(string str)
    {
        if (str is null)
            return String.Empty;

        StringBuilder output = new();
        HashSet<char> seen = new();
        foreach (var ch in str)
        {
            if (!seen.Contains(ch))
            {
                seen.Add(ch);
                output.Append(ch);
            }
        }
        return output.ToString();

        //HashSet<char> result = new();
        //foreach (var ch in str)
        //    result.Add(ch);
        //return string.Join("", result);


    }

    public static char GetMaxOccuringChar(string str)
    {
        if (string.IsNullOrEmpty(str))
            throw new ArgumentOutOfRangeException();

        const int ASCII_SIZE = 256;
        int[] freq = new int[ASCII_SIZE];
        foreach (var ch in str)
            freq[ch]++;

        var max = 0;
        char result = ' ';
        for (int i = 0; i < freq.Length; i++)
        {
            if (freq[i] > max)
            {
                max = freq[i];
                result = (char)i;
            }
        }
        return result;

        //using a dictionary (hashtable)
        //Dictionary<char, int> frequencies = new();
        //foreach (var ch in str)
        //{
        //    if (frequencies.ContainsKey(ch))
        //        frequencies[ch]++;
        //    else
        //        frequencies.Add(ch, 1);
        //}

        
    }

    public static string Capitalize(string sentence)
    {
        if (sentence is null || sentence.Trim().Length == 0)
            return string.Empty;

        sentence = Regex.Replace(sentence, @"\s+", " ");
        if (string.IsNullOrEmpty(sentence.Trim()))
            return string.Empty;

        string[] words = sentence.Trim().Split(" ");
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
        }

        return String.Join(" ", words);
    }

    //O (n log n)
    public static bool AreAnagrams(string first, string second)
    {
        if (first is null || second is null || 
            first.Length != second.Length)
            return false;

        var chars1 = first.ToLower().ToList();
        var chars2 = second.ToLower().ToList();

        //O (n log n) 

        chars1.Sort();  
        chars2.Sort();

        return chars1.SequenceEqual(chars2);
    }

    // O(n)
    public static bool AreAnagrams2(string first, string second)
    {
        // Using Histogramming

        if (first is null || second is null)
            return false;

        const int ENGLISH_ALPHABETH = 26;
        int[] frequencies = new int[ENGLISH_ALPHABETH];

        first = first.ToLower();
        // O(n)
        for (int i = 0; i < first.Length; i++)
            frequencies[first[i] - 'a']++;

        second = second.ToLower();
        // O(n)
        for (int i = 0; i < second.Length; i++)
        {
            var index = second[i] - 'a';
            if (frequencies[index] == 0)
                return false;

            frequencies[index]--;
        }

        return true;
    }

    public static bool IsAnagram(string word)
    {
        if (word is null)
            return false;

        int left = 0;
        int right = word.Length - 1;

        while (left < right)
            if (word[left++] != word[right--])
                return false;

        return true;

        //return word.SequenceEqual(word.Reverse());
    }

}

