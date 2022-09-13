using DataStructuresAndAlgorithms.DataUtils;

namespace DataStructuresAndAlgorithms.NonLinearStructures.UndirectedGraphs;

public class Path
{
    private List<string> nodes = new();
    public void Add(string node)
    {
        nodes.Add(node);
    }
    public override string ToString() => Utils.Array2String(nodes);
}
