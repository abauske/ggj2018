using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Synapse : MonoBehaviour, ISynapseConnection {


    public Node AccessibleNode
    {
        get { return to;}
        set { to = value; }
    }
    public float Weight { get; set; }

    public Node from { get; set; }
    public Node to { get; set; }

    private LineRenderer line;

    // Use this for initialization
    public void Start ()
    {
        line = gameObject.AddComponent<LineRenderer>();
        drawConnection();

        registerSynapse();
    }

    void registerSynapse()
    {
        Weight = Vector3.Distance(from.transform.position, to.transform.position);
        from.AddConnection(this);
//        to.AddConnection(new SynapseConnection { AccessibleNode = from, Weight = this.Weight }); // as long as synapses are non directional
    }

    void drawConnection()
    {
        line.useWorldSpace = false;
        line.positionCount = 2;
        line.SetPosition(0, from.transform.position);
        line.SetPosition(1, to.transform.position);
        line.startColor = Color.black;
        line.endColor = Color.black;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.material.color = Color.black;
        line.numCornerVertices = 10;
    }

    public abstract bool transferData(Data_Script data);
    public abstract bool canTransfer(Shape data);
}
