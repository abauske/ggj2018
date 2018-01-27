using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphSearch : IGraphSearch {
    public IGraphSearch Predecessor { get; set; }
    public float PathLength { get; set; }
    public Node CurrentNode { get; set; }
    public bool Visited { get; set; }

    public GraphSearch()
    {
        Visited = false;
    }

    public IGraphSearch shortestPath(Shape shape, List<IGraphSearch> reachable)
    {
        Visited = true;
        if (CurrentNode.shape == shape)
        {
            return this;
        }


        foreach (var con in CurrentNode.getConnections())
        {
            if (reachable.Find(r => r.CurrentNode == con.AccessibleNode) == null)
            {
                reachable.Add(new GraphSearch { PathLength = PathLength + con.Weight, CurrentNode = con.AccessibleNode, Predecessor = this });
            }

        }
        
        var closestNextNode = getClosest(reachable);
        return closestNextNode != null ? closestNextNode.shortestPath(shape, reachable) : null;
    }

    private IGraphSearch getClosest(List<IGraphSearch> reachable)
    {
        IGraphSearch closest = null;
        float closestDistance = float.MaxValue;
        foreach (var con in reachable)
        {
            if (!con.Visited && con.PathLength < closestDistance)
            {
                closestDistance = con.PathLength;
                closest = con;
            }
        }

        return closest;
    }
}
