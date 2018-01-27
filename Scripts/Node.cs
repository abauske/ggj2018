using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Sprite NodeType1;
    public Sprite NodeType2;
    public Sprite NodeType3;

    internal Shape shape;

    protected List<ISynapseConnection> Connections = new List<ISynapseConnection>();

    public void AddConnection(ISynapseConnection con)
    {
        Connections.Add(con);
    }

    public void RemoveConnection(ISynapseConnection con)
    {
        Connections.Remove(con);
    }


    public List<IGraphSearch> getShortestPathTo(Shape shape)
    {
        var searchTree = new List<IGraphSearch>();
        var thisNode = new GraphSearch {CurrentNode = this, PathLength = 0, Predecessor = null, Visited = true};

        if (shape == this.shape)
        {
            var path = new List<IGraphSearch> {thisNode};
            return path;
        }

        List<IGraphSearch> reachable = new List<IGraphSearch> {thisNode};

        return thisNode.shortestPath(shape, reachable);
    }

    public List<ISynapseConnection> getConnections()
    {
        return this.Connections;
    }

    public void setShape(Shape s)
    {
        shape = s;
        switch (shape)
        {
            case Shape.TRIANGLE:
                this.GetComponent<Image>().sprite = NodeType1; // Dreieck
                break;
            case Shape.SQUARE:
                this.GetComponent<Image>().sprite = NodeType2; //Viereck
                break;
            case Shape.CIRCLE:
                this.GetComponent<Image>().sprite = NodeType3; //Kreis
                break;

            default: break;
        }
    }
}
