using DataStructuresAndAlgorithms.DataUtils;

namespace DataStructuresAndAlgorithms.NonLinearStructures.Graphs;

public static class GraphDemo
{
    public static void Demo()
    {
        var graph = new MyGraph();
        //graph.AddNode("A");
        //graph.AddNode("B");
        //graph.AddNode("C");
        //graph.AddEdge("A", "B");
        //graph.AddEdge("A", "C");
        //graph.RemoveEdge("A", "C");
        //graph.RemoveNode("B");
        //graph.RemoveNode("A");
        //graph.AddEdge("B", "C");
        //graph.Print();

        //graph.AddNode("A");
        //graph.AddNode("B");
        //graph.AddNode("C");
        //graph.AddNode("D");
        //graph.AddEdge("A", "B");
        //graph.AddEdge("B", "D");
        //graph.AddEdge("D", "C");
        //graph.AddEdge("A", "C");
        //graph.TraverseDepthFirst("C");
        //graph.TraverseDepthFirstIterative("B");

        //graph.TraverseBreathFirst("D");

        //graph.AddNode("X");
        //graph.AddNode("A");
        //graph.AddNode("B");
        //graph.AddNode("P");
        //graph.AddEdge("X", "A");
        //graph.AddEdge("X", "B");
        //graph.AddEdge("A", "P");
        //graph.AddEdge("B", "P");
        ////var result = graph.TopologicalSort();
        //Console.WriteLine($"TopologicalSort: {Utils.Array2String(result)}");


        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddEdge("A", "B");
        graph.AddEdge("B", "C");
        //graph.AddEdge("C", "A");
        graph.AddEdge("A", "C");
        Console.WriteLine($"Has Cycle: {graph.HasCycle()}");
    }
}

