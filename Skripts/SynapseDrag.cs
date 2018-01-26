using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynapseDrag : MonoBehaviour
{
    public LineRenderer line;

    private Vector3 dragStart;
    private Knot destination;

    void OnMouseDown()
    {
        dragStart = gameObject.transform.position;
    }

    void OnMouseDrag()
    {
        destination = null;

        var currentPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        line.SetPosition(0, new Vector2(0, 0));
        line.SetPosition(1, currentPos - dragStart);
        line.gameObject.SetActive(true);
        line.positionCount = 200;

        var hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
        if (hit.transform)
        {
            Debug.Log("transform");
            var knot = hit.transform.GetComponent<Knot>();
            if (knot)
            {
                line.SetPosition(1, hit.transform.gameObject.transform.position - dragStart);
                destination = knot;
            }
        }
    }

    void OnMouseUp()
    {
        if (destination)
        {
            var synapseGameObject = new GameObject("synapse");
            var synapse = synapseGameObject.AddComponent<Synapse>();
            synapse.from = gameObject.GetComponent<Knot>();
            synapse.to = destination;
        }

        line.gameObject.SetActive(false);
    }

    // Use this for initialization
	void Start ()
	{
	    Debug.Log("start");
    }
	
	// Update is called once per frame
	void Update ()
	{
    }
}
