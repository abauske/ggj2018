using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Sprite TriangleImg;
    public Sprite SqareImg;
    public Sprite CircleImg;

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
                this.GetComponent<SpriteRenderer>().sprite = TriangleImg; // Dreieck
                break;
            case Shape.SQUARE:
                this.GetComponent<SpriteRenderer>().sprite = SqareImg; //Viereck
                break;
            case Shape.CIRCLE:
                this.GetComponent<SpriteRenderer>().sprite = CircleImg; //Kreis
                break;

            default: break;
        }
    }
}
