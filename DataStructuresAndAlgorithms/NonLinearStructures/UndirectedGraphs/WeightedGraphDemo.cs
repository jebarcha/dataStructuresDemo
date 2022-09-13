using DataStructuresAndAlgorithms.DataUtils;

namespace DataStructuresAndAlgorithms.NonLinearStructures.UndirectedGraphs;

public static class WeightedGraphDemo
{
    public static void Demo()
    {
        var graph = new MyWeightedGraph();
        //graph.AddNode("A");
        //graph.AddNode("B");
        //graph.AddNode("C");
        //graph.AddEdge("A", "B", 3);
        //graph.AddEdge("A", "C", 2);
        //graph.Print();

        //graph.AddNode("A");
        //graph.AddNode("B");
        //graph.AddNode("C");
        //graph.AddEdge("A", "B", 1);
        //graph.AddEdge("B", "C", 2);
        //graph.AddEdge("A", "C", 10);
        ////var path = graph.GetShortestPath("A", "C");
        //var path = graph.GetShortestPath("A", "K");
        //Console.WriteLine($"GetShortestPath: {path}");


        //graph.AddNode("A");
        //graph.AddNode("B");
        //graph.AddNode("C");
        //graph.AddEdge("A", "B", 0);
        //graph.AddEdge("B", "C", 0);
        //graph.AddEdge("C", "A", 0);
        //Console.WriteLine($"HasCycle: {graph.HasCycle()}");


        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddNode("D");
        graph.AddEdge("A", "B", 3);
        graph.AddEdge("B", "D", 4);
        graph.AddEdge("C", "D", 5);
        graph.AddEdge("A", "C", 1);
        graph.AddEdge("B", "C", 2);
        var tree = graph.GetMinimumSpanningTree();
        tree.Print();

    }

}
