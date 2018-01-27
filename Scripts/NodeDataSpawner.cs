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
    private int datenAmount = 0;
    private double Vectorlength = 0.5;
    private int counter = 0;
    private float spawnTime;
    public float spawnIntervall = 6;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (datenAmount >= lostDataCount)
        {
            //Game end.
        }
        else
        {
            if (Time.time > spawnTime)
            {
                spawnTime = Time.time + spawnIntervall;
                counter += 1;
                datenAmount += 1;
                Shape s;
                do
                {
                    s = (Shape) Random.Range(0, System.Enum.GetNames(typeof(Shape)).Length);
                } while (s == shape);

                GameObject dataObject = Instantiate(dataPrefab, this.transform.position, new Quaternion(0, 0, 0, 0), this.transform);

                Vector3 v = arangeData();
                dataObject.transform.position += v;

                dataObject.SetActive(true);
                var d = dataObject.GetComponent<Data_Script>();
                d.setShape(s);
//                dataObject.transform.SetParent(this.transform);
//                dataObject.transform.position = transform.position + Vector3.down;
//                dataObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                
                //daten.Add(d);
                
                
                if ((counter % spawnSpeed) == 0) // alle 10 counts wird schneller gespawnt
                {
                    spawnIntervall = spawnIntervall * Random.Range(0.98f, 0.99f);
                    counter = 0;
                }
            }
        }
        this.trySendData();
    }

    
    public Vector3 arangeData()
    {
        float x = 0;
        float y = 0;

        float winkel = (float) (2 * System.Math.PI) / lostDataCount;
        Debug.Log(winkel + ", " + winkel * (datenAmount));
        winkel = winkel * (float)(datenAmount) ;
        

        x = (float)(Vectorlength * (System.Math.Cos(winkel)));
        y = (float)(Vectorlength * (System.Math.Sin(winkel)));
        Debug.Log(x + ", " + y);
        return new Vector3(x,y,0);
    }
    
    /*
        public Vector3 arangeData(int i)
    {
        return new Vector3(i,1.0f,0);
    }
    */

    public void rearangeData()
    {
        int i = 0;
        foreach (Data_Script d in daten)
        {
            d.transform.position += arangeData();
            i++;
        }

    }

    public void addData(Data_Script newData)
    {
        daten.Add(newData);
        rearangeData();
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
