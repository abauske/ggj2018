using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynapseConnection : ISynapseConnection {
    
    public Node AccessibleNode { get; set; }
    public float Weight { get; set; }
}
