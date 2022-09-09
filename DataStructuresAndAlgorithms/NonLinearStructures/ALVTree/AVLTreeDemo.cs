namespace DataStructuresAndAlgorithms.NonLinearStructures.AVLTree;
public static class AVLTreeDemo
{
    public static void MyAVLTree()
    {
        MyAVLTree avlTree = new MyAVLTree();
        avlTree.Insert(10);
        avlTree.Insert(30);
        avlTree.Insert(20);
        //10
        //  20
        //    30
        
        Console.WriteLine($"IsBalanced: {avlTree.IsBalanced()}");

        Console.WriteLine($"IsPefect: {avlTree.IsPerfect()}");

    }
}
