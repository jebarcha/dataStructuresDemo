using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.NonLinearStructures.BinaryTrees
{
    public class MyTree
    {
        public class Node
        {
            public int value;
            public Node leftChild;
            public Node rightChild;

            public Node(int value)
            {
                this.value = value;
            }

            public override string ToString()
            {
                return $"Node={value}";
            }
        }

        private Node root;

        public void Insert(int value)
        {
            var node = new Node(value);

            if (root == null)
            {
                root = node;
                return;
            }

            var current = root;
            while (true)
            {
                if (value < current.value)
                {
                    if (current.leftChild == null)
                    {
                        current.leftChild = node;
                        break;
                    }
                    current = current.leftChild;
                }
                else
                {
                    if (current.rightChild == null)
                    {
                        current.rightChild = node;
                        break;
                    }
                    current = current.rightChild;
                }
            }
        }

        public bool Find(int value)
        {
            var current = root;
            while (current != null)
            {
                if (value < current.value)
                {
                    current = current.leftChild;
                }
                else if (value > current.value)
                {
                    current = current.rightChild;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public void TraversePreOrder()
        {
            TraversePreOrder(root);
        }
        private void TraversePreOrder(Node root)
        {
            if (root == null)
                return;

            // root (print)
            Console.WriteLine(root.value);
            // left
            TraversePreOrder(root.leftChild);
            // right
            TraversePreOrder(root.rightChild);
        }

        public void TraverseInOrder()
        {
            TraverseInOrder(root);
        }
        private void TraverseInOrder(Node root)
        {
            if (root == null)
                return;

            TraverseInOrder(root.leftChild);
            Console.WriteLine(root.value);
            TraverseInOrder(root.rightChild);
        }

        private void TraversePostOrder(Node root)
        {
            if (root == null)
                return;

            TraversePostOrder(root.leftChild);
            TraversePostOrder(root.rightChild);
            Console.WriteLine(root.value);
        }

        public int Height() => Height(root);
        private int Height(Node root)
        {
            if (root == null) 
                return -1;
            if (IsLeaf(root))
                return 0;

            return 1 + Math.Max(
                Height(root.leftChild), 
                Height(root.rightChild));
        }

        // O(log n)
        public int Min()
        {
            //return Min(root);

            if (root == null)
                throw new ArgumentOutOfRangeException();

            var current = root;
            var last = current;
            while (current != null) {
                last = current;
                current = current.leftChild;
            }
            return last.value;
        }

        // O(n)
        private int Min(Node root)
        {
            if (IsLeaf(root))
                return root.value;

            var left = Min(root.leftChild);
            var right = Min(root.rightChild);

            return Math.Min(Math.Min(left, right), root.value);
        }

        private bool IsLeaf(Node node) => node.leftChild == null && node.rightChild == null;

        public bool Equals(MyTree other)
        {
            if (other == null)
                return false;

            return Equals(root, other.root);
        }
        private bool Equals(Node first, Node second)
        {
            if (first == null && second == null)
                return true;

            if (first != null && second != null)
            {
                return first.value == second.value
                    && Equals(first.leftChild, second.leftChild)
                    && Equals(first.rightChild, second.rightChild);
            }

            return false;
        }

        public void SwapRoot()
        {
            var temp = root.leftChild;
            root.leftChild = root.rightChild;
            root.rightChild = temp;
        }

        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(root, int.MinValue, int.MaxValue);
        }
        private bool IsBinarySearchTree(Node root, int min, int max)
        {
            if (root is null)  //is a  BST
            {
                return true;
            }

            if (root.value < min || root.value > max)
            {
                return false;
            }

            return IsBinarySearchTree(root.leftChild, min, root.value - 1)
                   && IsBinarySearchTree(root.rightChild, root.value - 1, max);
        }


        public List<int> GetNodesAtDistance(int distance)
        {
            var list = new List<int>();
            GetNodesAtDistance(root, distance, list);
            return list;
        }
        private void GetNodesAtDistance(Node root, int distance, List<int> list)
        {
            if (root is null)
            {
                return;
            }

            if (distance == 0)
            {
                list.Add(root.value);
                //Console.WriteLine(root.value);
                return;
            }

            GetNodesAtDistance(root.leftChild, distance - 1, list);
            GetNodesAtDistance(root.rightChild, distance - 1, list);
        }


        public void TraverseLevelOrder()
        {
            for (int i = 0; i <= Height(); i++)
            {
                var list = GetNodesAtDistance(i);
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
        }


        #region MoreDemos
        public int Size()
        {
            //The size of a binary tree is the number of nodes
            return Size(root);
        }
        private int Size(Node root)
        {
            if (root == null)
                return 0;

            if (IsLeaf(root))  //a leaf itself has size 1
                return 1;

            return 1 + Size(root.leftChild) + Size(root.rightChild);
        }

        public int CountLeaves()
        {
            return CountLeaves(root);
        }
        private int CountLeaves(Node root)
        {
            if (root == null)
                return 0;

            if (IsLeaf(root))
                return 1;

            return CountLeaves(root.leftChild) + CountLeaves(root.rightChild);
        }

        public int Max()
        {
            if (root == null)
                throw new ArgumentOutOfRangeException();

            return Max(root);
        }
        private int Max(Node root)
        {
            if (root.rightChild == null)
                return root.value;

            return Max(root.rightChild);
        }

        public bool Contains(int value)
        {
            return Contains(root, value);
        }
        private bool Contains(Node root, int value)
        {
            if (root == null)
                return false;

            if (root.value == value)
                return true;

            return Contains(root.leftChild, value) || Contains(root.rightChild, value);
        }

        public bool AreSibling(int first, int second)
        {
            return AreSibling(root, first, second);
        }
        private bool AreSibling(Node root, int first, int second)
        {
            if (root == null)
                return false;

            var areSibling = false;
            if (root.leftChild != null && root.rightChild != null)
            {
                areSibling = (root.leftChild.value == first && root.rightChild.value == second) ||
                             (root.rightChild.value == first && root.leftChild.value == second);
            }

            return areSibling ||
                    AreSibling(root.leftChild, first, second) ||
                    AreSibling(root.rightChild, first, second);
        }

        public List<int> GetAncestors(int value)
        {
            //The ancestor of a node in a binary tree is a node that is at the upper level of the given node
            var list = new List<int>();
            GetAncestors(root, value, list);
            return list;
        }
        private bool GetAncestors(Node root, int value, List<int> list)
        {
            // We should traverse the tree until we find the target value. If
            // find the target value, we return true without adding the current node
            // to the list; otherwise, if we ask for ancestors of 5, 5 will be also
            // added to the list.
            if (root == null)
                return false;

            if (root.value == value)
                return true;

            // If we find the target value in the left or right sub-trees, that means
            // the current node (root) is one of the ancestors. So we add it to the list.
            if (GetAncestors(root.leftChild, value, list) ||
                GetAncestors(root.rightChild, value, list))
            {
                list.Add(root.value);
                return true;
            }

            return false;
        }
        #endregion
    }
}
