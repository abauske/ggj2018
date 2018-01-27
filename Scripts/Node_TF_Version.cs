using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node_TF_VErsion : MonoBehaviour
{
    private Shape shape;
    public Sprite NodeType1;
    public Sprite NodeType2;
    public Sprite NodeType3;

    public List<GameObject> daten;

    public int spawnSpeed = 10;
    private int dataTypesAmount = 3;

    public int counter = 0;
    public float spawnTime;
    public float spawnIntervall = 1;

    // Use this for initialization
    void Start()
    {
        daten = new List<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (daten.Count > dataTypesAmount)
        {
            //Game end.
        }
        else
        {
            if (Time.time > spawnTime)
            {
                spawnTime = Time.time + spawnIntervall;
                counter += 1;
                int i = (int)Random.Range(1.0f, (float)dataTypesAmount);

                GameObject datum1 = new GameObject();
                Data_Script d = datum1.AddComponent<Data_Script>();
                d.setShape((Shape)i);
                
                daten.Add(datum1);
                datum1.transform.position = this.transform.position;


                if ((counter % spawnSpeed) == 0) // alle 10 counts wird schneller gespawnt
                {
                    spawnIntervall = spawnIntervall * Random.Range(0.98f, 0.99f);
                    counter = 0;
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
