using System;
using System.Security;
using System.Text;

namespace DataStructuresAndAlgorithms.NonLinearStructures.Tries;
public class Trie
{
    //public static int ALPHABETH_SIZE = 26;

    private class Node
    {
        public char value;
        //public Node[] children = new Node[ALPHABETH_SIZE];
        public Dictionary<char, Node> children = new Dictionary<char, Node>();
        public bool isEndOfWord;

        public Node(char value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return $"value={value}";
        }

        public bool HasChild(char ch) => children.ContainsKey(ch);
        public void AddChild(char ch) => children.Add(ch, new Node(ch));
        public Node GetChild(char ch) => children.ContainsKey(ch) ? children[ch] : null;
        public Node[] GetChildren() => children.Values.ToArray();
        public bool HasChildren() => children.Count > 0;
        public void RemoveChild(char ch) => children.Remove(ch);
    }

    private Node root = new Node(' ');

    public void Insert(string word)
    {
        var current = root;
        foreach (var ch in word)
        {
            if (!current.HasChild(ch))
            {
                current.AddChild(ch);
            }
            current = current.GetChild(ch);
        }
        current.isEndOfWord = true;
    }
    //public void Insert(string word)
    //{
    //    var current = root;
    //    foreach (var ch in word)
    //    {
    //        var index = ch - 'a';
    //        if (current.children[index] is null)
    //        {
    //            current.children[index] = new Node(ch);
    //        }
    //        current = current.children[index];
    //    }
    //    current.isEndOfWord = true;
    //}
    public bool Contains(string word)
    {
        if (word is null)
        {
            return false;
        }
        var current = root;
        foreach (var ch in word)
        {
            if (!current.HasChild(ch) )
            {
                return false;
            }
            current=current.GetChild(ch);    
        }
        return current.isEndOfWord;
    }

    public void TraversePreOrder()
    {
        TraversePreOrder(root);
    }
    private void TraversePreOrder(Node root)
    {
        //Pre-order: visit the root first
        Console.WriteLine(root.value);

        foreach (var child in root.GetChildren())
        {
            TraversePreOrder(child);
        }
    }

    public void TraversePostOrder()
    {
        TraversePostOrder(root);
    }
    private void TraversePostOrder(Node root)
    {
        //Post-order: visit the children first
        foreach (var child in root.GetChildren())
        {
            TraversePostOrder(child);
        }

        Console.WriteLine(root.value);

    }

    public void Remove(string word)
    {
        if (word is null)
        {
            return;
        }

        Remove(root, word, 0);
    }
    private void Remove(Node root, string word, int index)
    {
        if (index == word.Length) //base condition that terminates the recursion
        {
            //Console.WriteLine(root.value);
            root.isEndOfWord = false;
            return;
        }

        var ch = word[index];
        var child = root.GetChild(ch);
        if (child is null)
        {
            return;
        }

        Remove(child, word, index + 1);
        //Console.WriteLine(root.value);
        
        if (!child.HasChildren() && !child.isEndOfWord)
        {
            root.RemoveChild(ch);
        }
    }

    public List<string> FindWords(string prefix)
    {
        List<string> words = new List<string>();
        var lastNode = FindLastNodeOf(prefix);
        FindWords(lastNode, prefix, words);

        return words;
    }
    private void FindWords(Node root, string prefix, List<string> words)
    {
        if (root is null)
        {
            return;
        }

        if (root.isEndOfWord)
        {
            words.Add(prefix);
        }

        foreach (var child in root.GetChildren())
        {
            FindWords(child, prefix + child.value, words);
        }

    }
    private Node FindLastNodeOf(string prefix)
    {
        if (prefix is null)
        {
            return null;
        }

        var current = root;
        foreach (var ch in prefix)
        {
            var child = current.GetChild(ch);
            if (child is null)
            {
                return null;
            }
            current = child;
        }
        return current;
    }

    public bool ContainsRecursive(String word)
    {
        if (word == null)
            return false;

        return ContainsRecursive(root, word, 0);
    }
    private bool ContainsRecursive(Node root, String word, int index)
    {
        // Base condition
        if (index == word.Length)
            return root.isEndOfWord;

        if (root == null)
            return false;

        var ch = word[index];
        var child = root.GetChild(ch);
        if (child == null)
            return false;

        return ContainsRecursive(child, word, index + 1);
    }

    public int CountWords()
    {
        return CountWords(root);
    }
    private int CountWords(Node root)
    {
        var total = 0;

        if (root.isEndOfWord)
            total++;

        foreach (var child in root.GetChildren())
        {
            total += CountWords(child);
        }

        return total;
    }

    public string LongestCommonPrefix(string[] words)
    {
        if (words == null)
            return "";

        var trie = new Trie();
        foreach (var word in words)
        {
            trie.Insert(word);
        }

        var prefix = new StringBuilder(); //StringBuffer();
        var maxChars = GetShortest(words).Length;
        var current = trie.root;
        while (prefix.Length < maxChars)
        {
            var children = current.GetChildren();
            if (children.Length != 1)
                break;
            current = children[0];
            prefix.Append(current.value);
        }

        return prefix.ToString();
    }
    private static string GetShortest(String[] words)
    {
        if (words == null || words.Length == 0)
            return "";

        var shortest = words[0];
        for (var i = 1; i < words.Length; i++)
        {
            if (words[i].Length < shortest.Length)
                shortest = words[i];
        }

        return shortest;
    }
}

