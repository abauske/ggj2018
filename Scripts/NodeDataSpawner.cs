using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeDataSpawner : Node
{
    public Sprite NodeType1;
    public Sprite NodeType2;
    public Sprite NodeType3;

    private List<Data_Script> daten = new List<Data_Script>();
    private int lostDataCount = 6;
    public int spawnSpeed = 10;

    private int counter = 0;
    private float spawnTime;
    public float spawnIntervall = 4;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (daten.Count > lostDataCount)
        {
            //Game end.
        }
        else
        {
            if (Time.time > spawnTime)
            {
                spawnTime = Time.time + spawnIntervall;
                counter += 1;
                int i = (int) Random.Range(1.0f, (float) System.Enum.GetNames(typeof(Shape)).Length);

                GameObject dataObject = new GameObject();
                dataObject.AddComponent<Image>();
                Data_Script d = dataObject.AddComponent<Data_Script>();
                d.setShape((Shape) i);
                addData(d);


                if ((counter % spawnSpeed) == 0) // alle 10 counts wird schneller gespawnt
                {
                    spawnIntervall = spawnIntervall * Random.Range(0.98f, 0.99f);
                    counter = 0;
                }
            }
        }
        this.trySendData();
    }

    public void addData(Data_Script data)
    {
        daten.Add(data);
        gameObject.transform.position = this.transform.position;
    }

    private void trySendData()
    {
        foreach (var d in daten)
        {
            var path = getShortestPathTo(d.shape);
            if (path.Count == 1)
            {
                Destroy(d.gameObject);
            }
            else if (path.Count > 1)
            {
                bool removed = path[1].connection.transferData(d);
                if (removed)
                {
                    daten.Remove(d);
                }
            }
        }
    }

    public void setShape(Shape s)
    {
        shape = s;
        switch (shape)
        {
            case Shape.TRIANGLE:
                this.GetComponent<Image>().sprite = NodeType1; // Dreieck
                break;
            case Shape.SQUARE:
                this.GetComponent<Image>().sprite = NodeType2; //Viereck
                break;
            case Shape.CIRCLE:
                this.GetComponent<Image>().sprite = NodeType3; //Kreis
                break;

            default: break;
        }
    }
}
