using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryangleSynScript : MonoBehaviour
{

    //private SingleShapeSynapse syn;

    //public void Start()
    //{

    //    syn = new SingleShapeSynapse();
    //    syn.transferable = Shape.TRIANGLE;
    //    syn.
    //    syn.Start();


    //}

    public LineRenderer line;

    private Vector3 dragStart;
    private Node destination;

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
        if (destination)
        {
            var synapseGameObject = new GameObject("singleShapeSynapse");
            var synapse = synapseGameObject.AddComponent<SingleShapeSynapse>();
            synapse.transferable = Shape.TRIANGLE;
            synapse.from = gameObject.GetComponent<Node>();
            synapse.to = destination;
        }

        line.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
