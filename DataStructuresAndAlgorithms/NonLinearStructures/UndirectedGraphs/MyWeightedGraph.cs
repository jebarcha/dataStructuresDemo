using DataStructuresAndAlgorithms.DataUtils;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.NonLinearStructures.UndirectedGraphs;
public class MyWeightedGraph
{
    private class Node
    {
        public string label;
        public List<Edge> edges = new List<Edge>();
        public Node(string label)
        {
            this.label = label;
        }
        public override string ToString()
        {
            return label;
        }
        public void AddEdge(Node to, int weight)
        {
            edges.Add(new Edge(this, to, weight));
        }
        public List<Edge> GetEdges() => edges;
    }

    private class Edge
    {
        public Node from;
        public Node to;
        public int weight;
        public Edge(Node from, Node to, int weight)
        {
            this.from = from;
            this.to = to;
            this.weight = weight;
        }

        public override string ToString()
        {
            return $"{from}->{to}";
        }
    }

    private Dictionary<string, Node> nodes = new Dictionary<string, Node>();
    //private Dictionary<Node, List<Edge>> adjacencyList = new Dictionary<Node, List<Edge>>();

    public void AddNode(string label)
    {
        nodes.TryAdd(label, new Node(label));

        //var node = new Node(label);
        //nodes.TryAdd(label, node);
        //adjacencyList.TryAdd(node, new List<Edge>());
    }
    public void AddEdge(string from, string to, int weight)
    {
        var fromNode = nodes[from];
        if (fromNode is null)
            throw new ArgumentOutOfRangeException();

        var toNode = nodes[to];
        if (toNode is null)
            throw new ArgumentOutOfRangeException();

        fromNode.AddEdge(toNode, weight);
        toNode.AddEdge(fromNode, weight);

        //adjacencyList[fromNode].Add(new Edge(fromNode, toNode, weight));
        //adjacencyList[toNode].Add(new Edge(toNode, fromNode, weight));
    }
    public void Print()
    {
        foreach (var node in nodes.Values)
        {
            var edges = node.GetEdges();
            if (edges.Count > 0)
                Console.WriteLine($"{node} is connected to {Utils.Array2String(edges)}");
        }
        //foreach (var source in adjacencyList.Keys)
        //{
        //    var targets = adjacencyList[source];
        //    if (targets.Count > 0)
        //        Console.WriteLine($"{source} is connected to {Utils.Array2String(targets)}");
        //}
    }

    private class NodeEntry
    {
        public Node node;
        public int priority;
        public NodeEntry(Node node, int priority)
        {
            this.node = node;
            this.priority = priority;
        }
    }
    private class IntMaxCompare : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }
    private class IntMinCompare : IComparer<int>
    {
        public int Compare(int x, int y) => x.CompareTo(y);
    }
    //actual IL code:
    //public int CompareTo(int value)
    //{
    //    if (m_value < value) return -1;
    //    if (m_value > value) return 1;
    //    return 0;
    //}
    public Path GetShortestPath(string from, string to)
    {
        //Descending Sort, Integer
        //var queue = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
        ////Ascending Sort, Object
        //var queue = new PriorityQueue<ObjectA, ObjectB>(Comparer<ObjectB>.Create((x, y) => x.Something.CompareTo(y.Something));

        if (!nodes.ContainsKey(from))
            throw new ArgumentOutOfRangeException();
        var fromNode = nodes[from];
        
        if (!nodes.ContainsKey(to))
            throw new ArgumentOutOfRangeException();
        var toNode = nodes[to];

        Dictionary<Node, int> distances = new();
        foreach (var node in nodes.Values)
            distances.Add(node, int.MaxValue);
        distances[fromNode] = 0;

        Dictionary<Node, Node> previousNodes = new();

        HashSet<Node> visited = new();

        PriorityQueue<NodeEntry, int> queue = new PriorityQueue<NodeEntry, int>(
                new IntMinCompare()
            );
        queue.Enqueue(new NodeEntry(fromNode, 0), 0);

        while(queue.Count > 0)
        {
            var current = queue.Dequeue().node;
            visited.Add(current);

            foreach (var edge in current.GetEdges())
            {
                if (visited.Contains(edge.to))
                    continue;

                var newDistance = distances[current] + edge.weight;
                if (newDistance < distances[edge.to])
                {
                    distances[edge.to] = newDistance;
                    if (!previousNodes.ContainsKey(edge.to))
                    {
                        previousNodes.Add(edge.to, current);
                    }
                    else
                    {
                        previousNodes[edge.to] = current;
                    }
                    queue.Enqueue(new NodeEntry(edge.to, newDistance), 0);
                }
            }
        }

        return BuildPath(previousNodes, toNode);
    }
    private Path BuildPath(Dictionary<Node, Node> previousNodes, Node toNode)
    {
        Stack<Node> stack = new();
        stack.Push(toNode);
        var previous = previousNodes[toNode];
        while (previous != null)
        {
            stack.Push(previous);
            previous = previousNodes.ContainsKey(previous) ? previousNodes[previous] : null;
        }

        var path = new Path();
        while (stack.Count > 0)
        {
            path.Add(stack.Pop().label);
        }

        return path;
    }


    public bool HasCycle()
    {
        HashSet<Node> visited = new();

        foreach (var node in nodes.Values)
        {
            if (!visited.Contains(node) && 
                    HasCycle(node, null, visited))
                return true;
        }

        return false;
    }
    private bool HasCycle(Node node, Node parent, HashSet<Node> visited)
    {
        visited.Add(node);
        foreach (var edge in node.GetEdges())
        {
            if (edge.to == parent)
                continue;

            if (visited.Contains(edge.to) || 
                    HasCycle(edge.to, node, visited))
                return true;
        }

        return false;
    }


    public MyWeightedGraph GetMinimumSpanningTree()
    {
        MyWeightedGraph tree = new();

        if (nodes.Count == 0)
            return tree;

        PriorityQueue <Edge, int> edges = new(
            new IntMinCompare()
        );

        var startNode = nodes.Values.ToArray()[0];
        foreach (var edge in startNode.GetEdges())
            edges.Enqueue(edge, edge.weight);
        tree.AddNode(startNode.label);

        if (edges.Count == 0)
            return tree;

        while (tree.nodes.Count < nodes.Count)
        {
            //if (edges.Count == 0)
            //    continue;

            var minEdge = edges.Dequeue();
            var nextNode = minEdge.to;

            if (tree.ContainsNode(nextNode.label))
                continue;

            tree.AddNode(nextNode.label);
            tree.AddEdge(minEdge.from.label, nextNode.label, minEdge.weight);


            foreach (var edge in nextNode.GetEdges())
            {
                if (!tree.ContainsNode(edge.to.label))
                    edges.Enqueue(edge, edge.weight);
            }
        }

        return tree;
    }
    public bool ContainsNode(string label) => nodes.ContainsKey(label);


}

