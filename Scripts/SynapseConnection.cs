using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynapseConnection : ISynapseConnection {
    
    public Node AccessibleNode { get; set; }
    public float Weight { get; set; }

    public bool transferData(Data_Script data)
    {
        var destination = AccessibleNode.gameObject.GetComponent<NodeDataSpawner>();
        destination.addData(data);
        return true;
    }
}
