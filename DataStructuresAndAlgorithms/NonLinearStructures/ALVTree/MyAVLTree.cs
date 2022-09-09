using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using static DataStructuresAndAlgorithms.NonLinearStructures.BinaryTrees.MyTree;

namespace DataStructuresAndAlgorithms.NonLinearStructures.AVLTree;
public class MyAVLTree
{
    public class AVLNode
    {
        public int height;
        public int value;
        public AVLNode leftChild;
        public AVLNode rightChild;

        public AVLNode(int value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"AVLNode={value}";
        }
    }

    private AVLNode root;

    public void Insert(int value) //use recursion
    {
        root = Insert(root, value);
    }
    private AVLNode Insert(AVLNode root, int value)
    {
        if (root is null)
        {
            return new AVLNode(value);
        }

        if (value < root.value)
        {
            root.leftChild =  Insert(root.leftChild, value);
        }
        else
        {
            root.rightChild = Insert(root.rightChild, value);
        }

        SetHeight(root);
        
        return Balance(root);
    }

    public bool IsBalanced()
    {
        return IsBalanced(root);
    }

    private bool IsBalanced(AVLNode root)
    {
        if (root == null)
            return true;

        var balanceFactor = Height(root.leftChild) - Height(root.rightChild);

        return Math.Abs(balanceFactor) <= 1 &&
                IsBalanced(root.leftChild) &&
                IsBalanced(root.rightChild);
    }

    public bool IsPerfect()
    {
        //In a perfect binary tree, every level (except the last level) is full of nodes. 
        return Size() == (Math.Pow(2, Height() + 1) - 1);
    }
    private AVLNode Balance(AVLNode root)
    {
        if (IsLeftHeavy(root))
        {
            //Console.WriteLine($"{root.value} is left heavy");
            if (BalanceFactor(root.leftChild) < 0)
            {
                //Console.WriteLine($"Left Rotate {root.leftChild.value}");
                root.leftChild = RotateLeft(root.leftChild);
            }
            //Console.WriteLine($"Right Rotate {root.value}");
            return RotateRight(root);
        }
        else if (IsRightHeavy(root))
        {
            //Console.WriteLine($"{root.value} is right heavy");
            if (BalanceFactor(root.rightChild) > 0)
            {
                //Console.WriteLine($"Right Rotate {root.rightChild.value}");
                root.rightChild = RotateRight(root.rightChild);
            }
            //Console.WriteLine($"Left Rotate {root.value}");
            return RotateLeft(root);
        }
        
        return root;
    }
    private AVLNode RotateLeft(AVLNode root)
    {
        var newRoot = root.rightChild;
        root.rightChild = newRoot.leftChild;
        newRoot.leftChild = root;

        SetHeight(root);
        SetHeight(newRoot);

        return newRoot;
    }
    private AVLNode RotateRight(AVLNode root)
    {
        var newRoot = root.leftChild;
        root.leftChild = newRoot.rightChild;
        newRoot.rightChild = root;

        SetHeight(root);
        SetHeight(newRoot);

        return newRoot;
    }

    #region HelperMethods

    public int Size()
    {
        return Size(root);
    }

    private int Size(AVLNode root)
    {
        if (root == null)
            return 0;

        if (IsLeaf(root))
            return 1;

        return 1 + Size(root.leftChild) + Size(root.rightChild);
    }

    public int Height()
    {
        return Height(root);
    }

    private int Height(AVLNode root)
    {
        if (root == null)
            return -1;

        if (IsLeaf(root))
            return 0;

        return 1 + Math.Max(
                Height(root.leftChild),
                Height(root.rightChild));
    }

    private bool IsLeaf(AVLNode node) => node.leftChild == null && node.rightChild == null;

    private void SetHeight(AVLNode node)
    {
        node.height = Math.Max(Height(node.leftChild), Height(node.rightChild)) + 1;
    }
    private bool IsLeftHeavy(AVLNode node) => BalanceFactor(node) > 1;
    private bool IsRightHeavy(AVLNode node) => BalanceFactor(node) < -1;
    private int BalanceFactor(AVLNode node) => node is null ? 0 : Height(node.leftChild) - Height(node.rightChild);
    //private int Height(AVLNode node) => node is null ? -1 : node.height;
    #endregion

}
