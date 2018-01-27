using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    private List<ISynapseConnection> Connections = new List<ISynapseConnection>();

    public void AddConnection(ISynapseConnection con)
    {
        Connections.Add(con);
    }

    public void RemoveConnection(ISynapseConnection con)
    {
        Connections.Remove(con);
    }


}
