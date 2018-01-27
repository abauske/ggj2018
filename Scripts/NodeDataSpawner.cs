using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeDataSpawner : Node
{
    public GameObject dataPrefab;
    private List<Data_Script> daten = new List<Data_Script>();
    private int lostDataCount = 6;
    public int spawnSpeed = 10;

    private int Vectorlength = 1;
    private int counter = 0;
    private float spawnTime;
    public float spawnIntervall = 6;

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
                int i = Random.Range(0, System.Enum.GetNames(typeof(Shape)).Length);

                float x = this.transform.position.x;
                float y = this.transform.position.y;

                float winkel = 360 / lostDataCount;
                winkel *= daten.Count;

                y += Vectorlength * (float) System.Math.Sin(winkel);
                x += Vectorlength * (float)System.Math.Cos(winkel);


                GameObject dataObject = Instantiate(dataPrefab, new Vector2(x,y), new Quaternion(0, 0, 0, 0), this.transform);

                dataObject.SetActive(true);
                var d = dataObject.GetComponent<Data_Script>();
                d.setShape((Shape) i);
                // d.transform.SetParent(this.transform);
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
        daten.RemoveAll(d =>
        {
            var path = getShortestPathTo(d.shape);
            if (path == null)
            {
                return false;
            }

            if (path.Count == 1)
            {
                Debug.Log("destination reached");
                Destroy(d.gameObject);
                return true;
            }
            else if (path.Count > 1)
            {
                return path[1].connection.transferData(d);
            }

            return false;
        });
    }

    
}
