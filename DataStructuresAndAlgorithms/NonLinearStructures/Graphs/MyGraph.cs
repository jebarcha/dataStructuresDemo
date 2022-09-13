using DataStructuresAndAlgorithms.DataUtils;
using DataStructuresAndAlgorithms.Queue;

namespace DataStructuresAndAlgorithms.NonLinearStructures.Graphs;
public class MyGraph
{
    private class Node
    {
        public string label;
        public Node(string label)
        {
            this.label = label;
        }
        public override string ToString()
        {
            return label;
        }
    }

    private Dictionary<string, Node> nodes = new Dictionary<string, Node>();
    private Dictionary<Node, List<Node>> adjacencyList= new Dictionary<Node, List<Node>>();

    public void AddNode(string label)
    {
        var node = new Node(label);
        nodes.TryAdd(label, node);
        //if we don't put the line below we would need to add a null checking in the AddEdge method to make sure we don't have a null pointer exception or out of range exception.
        adjacencyList.TryAdd(node, new List<Node>()); //every node has an empty list where we can insert the nodes is connected to
    }
    public void RemoveNode(string label)
    {
        var node = nodes[label];
        if (node is null)
            return;

        foreach (var n in adjacencyList.Keys)
        {
            adjacencyList[n].Remove(node);
        }

        adjacencyList.Remove(node);
        nodes.Remove(node.label);
    }
    public void AddEdge(string from, string to)
    {
        var fromNode = nodes[from];
        if (fromNode is null)
            throw new ArgumentOutOfRangeException();

        var toNode = nodes[to];
        if (toNode is null)
            throw new ArgumentOutOfRangeException();

        adjacencyList[fromNode].Add(toNode);  //we don't have to do an extra null checking because the list was added in the AddNode method.
        //this is a directed graph (a non directed graph would be toNode to fromNode)
        //adjacencyList[toNode].Add(fromNode); //for undirected graph
    }
    public void RemoveEdge(string from, string to)
    {
        var fromNode = nodes[from];
        var toNode = nodes[to];
        if (fromNode is null || toNode is null)
            return;

        adjacencyList[fromNode].Remove(toNode);
    }
    public void Print()
    {
        foreach (var source in adjacencyList.Keys)
        {
            var targets = adjacencyList[source];
            if (targets.Count > 0)
            {
                Console.WriteLine($"{source} is connected to {Utils.Array2String(targets)}");
            }
        }
    }

    public void TraverseDepthFirst(string root)
    {
        if (!nodes.ContainsKey(root))
            return;

        TraverseDepthFirst(nodes[root], new HashSet<Node>());
    }
    private void TraverseDepthFirst(Node root, HashSet<Node> visited)
    {
        Console.WriteLine(root);
        visited.Add(root);

        foreach (var node in adjacencyList[root])
        {
            if (!visited.Contains(node))
            {
                TraverseDepthFirst(node, visited);
            }
        }
    }

    // Push(root)
    // While(stack is not empty)
    //   current = Pop()
    //   Visit(current)
    //   Push each unvisited neighbour onto the stack
    public void TraverseDepthFirstIterative(string root)
    {
        if (!nodes.ContainsKey(root))
            return;

        HashSet<Node> visited = new HashSet<Node>();

        Stack<Node> stack = new Stack<Node>();
        stack.Push(nodes[root]);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            if (visited.Contains(current))
                continue;

            Console.WriteLine(current);
            visited.Add(current);

            foreach (var neighbour in adjacencyList[current])
            {
                if (!visited.Contains(neighbour))
                    stack.Push(neighbour);
            }
        }

    }

    public void TraverseBreathFirst(string root)
    {
        if (!nodes.ContainsKey(root))
            return;

        HashSet<Node> visited = new HashSet<Node>();

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(nodes[root]);
        
        while (queue.Count > 0) {
            var current = queue.Dequeue();

            if (visited.Contains(current))
                continue;

            Console.WriteLine(current);
            visited.Add(current);

            foreach (var neightbour in adjacencyList[current])
            {
                if (!visited.Contains(neightbour))
                    queue.Enqueue(neightbour);
            }
        }

    }


    public List<string> TopologicalSort()
    {
        Stack<Node> stack = new Stack<Node>();
        HashSet<Node> visited = new HashSet<Node>();
        foreach (var node in nodes.Values)
        {
            TopologicalSort(node, visited, stack);
        }

        List<string> sorted = new List<string>();
        while (stack.Count > 0)
        {
            sorted.Add(stack.Pop().label);
        }

        return sorted;
    }
    private void TopologicalSort(Node node, HashSet<Node> visited, Stack<Node> stack)
    {
        if (visited.Contains(node))
            return;
    
        visited.Add(node);

        foreach (var neighbour in adjacencyList[node])
        {
            TopologicalSort(neighbour, visited, stack);
        }

        stack.Push(node);
    }


    public bool HasCycle()
    {
        HashSet<Node> all = new HashSet<Node>();
        foreach (var node in nodes.Values)
            all.Add(node);

        HashSet<Node> visiting = new HashSet<Node>();
        HashSet<Node> visited = new HashSet<Node>();

        while (all.Count > 0)
        {
            var current = all.ToArray()[0];
            if (HasCycle(current, all, visiting, visited))
                return true;
        }

        return false;
    }
    private bool HasCycle(Node node, HashSet<Node> all, HashSet<Node> visiting, HashSet<Node> visited)
    {
        all.Remove(node);
        visiting.Add(node);

        foreach (var neighbour in adjacencyList[node])
        {
            if (visited.Contains(neighbour))
                continue;

            if (visiting.Contains(neighbour))
                return true;

            if (HasCycle(neighbour, all, visiting, visited))
                return true;
        }

        visiting.Remove(node);
        visited.Add(node);

        return false;
    }
}

