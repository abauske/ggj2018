using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeDataSpawner : Node
{
    public GameObject dataPrefab;
    private List<GameObject> daten;
    private int lostDataCount = 6;
    public int spawnSpeed = 10;

    private int counter = 0;
    private float spawnTime;
    public float spawnIntervall = 1;

    // Use this for initialization
    void Start()
    {
        daten = new List<GameObject>();
    }

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
                int i = Random.Range(0,  System.Enum.GetNames(typeof(Shape)).Length);

                GameObject dataObject = Instantiate(dataPrefab, this.transform.position, new Quaternion(0, 0, 0, 0), this.transform);

                dataObject.SetActive(true);
                var d = dataObject.GetComponent<Data_Script>();
                d.setShape((Shape) i);
                // d.transform.SetParent(this.transform);
                
                daten.Add(dataObject);
                dataObject.transform.position = this.transform.position;


                if ((counter % spawnSpeed) == 0) // alle 10 counts wird schneller gespawnt
                {
                    spawnIntervall = spawnIntervall * Random.Range(0.98f, 0.99f);
                    counter = 0;
                }
            }
        }
    }

    
}
