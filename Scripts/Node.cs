﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Shape shape;

    protected List<ISynapseConnection> Connections = new List<ISynapseConnection>();

    public void AddConnection(ISynapseConnection con)
    {
        Connections.Add(con);
    }

    public void RemoveConnection(ISynapseConnection con)
    {
        Connections.Remove(con);
    }


    public IGraphSearch getShortestPathTo(Shape shape)
    {
        List<IGraphSearch> searchTree = new List<IGraphSearch>();
        var thisNode = new GraphSearch {CurrentNode = this, PathLength = 0, Predecessor = null, Visited = true};

        if (shape == this.shape)
        {
            return thisNode;
        }

        List<IGraphSearch> reachable = new List<IGraphSearch>();
        reachable.Add(thisNode);

        return thisNode.shortestPath(shape, reachable);
    }

    public List<ISynapseConnection> getConnections()
    {
        return this.Connections;
    }
}