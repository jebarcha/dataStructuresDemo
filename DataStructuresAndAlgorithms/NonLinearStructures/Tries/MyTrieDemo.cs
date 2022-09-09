using DataStructuresAndAlgorithms.DataUtils;

namespace DataStructuresAndAlgorithms.NonLinearStructures.Tries;

public static class MyTrieDemo
{
    public static void Demo()
    {
        var trie = new Trie();
        //trie.Insert("cat");
        //trie.Insert("can");
        //Console.WriteLine($"Contains the word cat: {trie.Contains("cat")}");
        //Console.WriteLine($"Contains the word canada: {trie.Contains("canada")}");
        //Console.WriteLine($"Contains null: {trie.Contains(null)}");
        //Console.WriteLine("Done");


        //trie.Insert("care");
        //trie.TraversePreOrder();
        //Console.WriteLine("");
        //trie.TraversePostOrder();

        //trie.Insert("car");
        //trie.Insert("care");
        //trie.Remove("care");
        //trie.Remove(null);
        //trie.Remove("ca");
        //trie.Remove("book");
        //Console.WriteLine($"car : {trie.Contains("car")}");
        //Console.WriteLine($"care: {trie.Contains("care")}");


        //trie.Insert("car");
        //trie.Insert("card");
        //trie.Insert("care");
        //trie.Insert("careful");
        //trie.Insert("egg");
        //var words = trie.FindWords(null);
        //Console.WriteLine(Utils.Array2String(words));
        //var words2 = trie.FindWords("");
        //Console.WriteLine(Utils.Array2String(words2));
        //var words3 = trie.FindWords("c");
        //Console.WriteLine(Utils.Array2String(words3));
        //var words4 = trie.FindWords("eg");
        //Console.WriteLine(Utils.Array2String(words4));


        //trie.Insert("cat");
        //trie.Insert("can");
        ////Console.WriteLine($"Contains Recursive the word cat: {trie.ContainsRecursive("cat")}");
        ////Console.WriteLine($"Contains Recursive the word canada: {trie.ContainsRecursive("canada")}");
        ////Console.WriteLine($"Contains Recursive null: {trie.ContainsRecursive(null)}");

        //Console.WriteLine($"CountWords: {trie.CountWords()}");

        string[] words1 = new string[] { "card", "care" };
        Console.WriteLine($"LongestCommonPrefix1: {trie.LongestCommonPrefix(words1)}");

        string[] words2 = new string[] { "car", "care" };
        Console.WriteLine($"LongestCommonPrefix 2: {trie.LongestCommonPrefix(words2)}");

        string[] words3 = new string[] { "car", "dog" };
        Console.WriteLine($"LongestCommonPrefix 3: {trie.LongestCommonPrefix(words3)}");

        string[] words4 = new string[] { "car" };
        Console.WriteLine($"LongestCommonPrefix 4: {trie.LongestCommonPrefix(words4)}");

    }
}



