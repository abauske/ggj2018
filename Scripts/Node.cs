using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Sprite Triangle;
    public Sprite Square;
    public Sprite Circle;

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

    public void setShape(Shape s)
    {
        shape = s;
        switch (shape)
        {
            case Shape.TRIANGLE:
                this.GetComponent<Image>().sprite = Triangle; // Dreieck
                break;
            case Shape.SQUARE:
                this.GetComponent<Image>().sprite = Square; //Viereck
                break;
            case Shape.CIRCLE:
                this.GetComponent<Image>().sprite = Circle; //Kreis
                break;

            default: break;
        }
    }
}
