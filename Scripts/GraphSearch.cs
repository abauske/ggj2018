using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphSearch : IGraphSearch {
    public IGraphSearch Predecessor { get; set; }
    public float PathLength { get; set; }
    public Node CurrentNode { get; set; }
    public Boolean Visited { get; set; }
    public ISynapseConnection connection { get; set; }

    public GraphSearch()
    {
        Visited = false;
    }

    public List<IGraphSearch> shortestPath(Shape shape, List<IGraphSearch> reachable)
    {
        List<IGraphSearch> path;
        Visited = true;
        if (CurrentNode.shape == shape)
        {
            path = new List<IGraphSearch> {this};
            return path;
        }


        foreach (var con in CurrentNode.getConnections())
        {
            var reach = reachable.Find(r => r.CurrentNode == con.AccessibleNode);
            var searchObject = new GraphSearch
            {
                PathLength = PathLength + con.Weight,
                CurrentNode = con.AccessibleNode,
                Predecessor = this,
                connection = con
            };
            if (reach != null)
            {
                reachable.Add(searchObject);
            } else if (reach.PathLength > PathLength + con.Weight)
            {
                var index = reachable.IndexOf(reach);
                if (index >= 0)
                {
                    reachable[index] = searchObject;
                }
            }

        }
        
        var closestNextNode = getClosest(reachable);
        if (closestNextNode == null) return null;
        path = closestNextNode.shortestPath(shape, reachable);
        if (path == null) return null;
        path.Insert(0, this);
        return path;
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
