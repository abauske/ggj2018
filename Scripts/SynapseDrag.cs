using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynapseDrag : MonoBehaviour
{
    public LineRenderer line;

    private Vector3 dragStart;
    private Node destination;

    private MoneyScript moneyScript;

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
        line.positionCount = 2;

        var cam = GameObject.FindGameObjectWithTag("MainCamera");
        if (cam != null && moneyScript.Money < cam.GetComponent<SynapseSelection>().price)
        {
            line.endColor = Color.red;
            line.startColor = Color.red;
        }
        else
        {
            line.endColor = Color.white;
            line.startColor = Color.white;
        }

        var hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
        if (hit.transform)
        {
            var node = hit.transform.GetComponent<Node>();
            if (node)
            {
                line.SetPosition(1, hit.transform.gameObject.transform.position - dragStart);
                destination = node;
            }
        }
    }

    void OnMouseUp()
    {

        line.gameObject.SetActive(false);
        var price = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SynapseSelection>().price;
        if (moneyScript.Money < price)
        {
            return;
        }
        var from = gameObject.GetComponent<Node>();
        if (destination != null && destination != from)
        {
            var synapseGameObject = new GameObject("synapse");

            var synapse = synapseGameObject.AddComponent<DefaultSynapse>();
            synapse.from = gameObject.GetComponent<Node>();
            synapse.to = destination;

            moneyScript.Money -= price;
        }
    }

    // Use this for initialization
	void Start ()
	{
	    moneyScript = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyScript>();
	}
	
	// Update is called once per frame
	void Update ()
	{
    }
}
