using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synapse : MonoBehaviour {

    public Knot from { get; set; }
    public Knot to { get; set; }

    private LineRenderer line;

    // Use this for initialization
    void Start ()
    {
        line = gameObject.AddComponent<LineRenderer>();
        drawConnection();

        registerSynapse();
    }

    void registerSynapse()
    {

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

    Vector3 getWorldCoords(GameObject go)
    {
        return go.transform.TransformPoint(go.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
