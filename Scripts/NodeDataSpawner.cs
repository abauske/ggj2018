using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NodeDataSpawner : Node
{
    public GameObject dataPrefab;
    private List<Data_Script> daten = new List<Data_Script>();
    private int lostDataCount = 8;
    public int spawnSpeed = 10;
    private double Vectorlength = 0.5;
    private int counter = 0;
    private float spawnTime;
    public float spawnIntervall = 6;
    
    
    private void Start()
    {

    }
    
    // Update is called once per frame
    void FixedUpdate()
    {

        if (daten.Count >= lostDataCount)
        {
            GameObject.FindGameObjectWithTag("endPanel").GetComponent<EndPanelScript>().endGame();
        }
        else
        {
            if (Time.time > spawnTime)
            {
                spawnTime = Time.time + spawnIntervall;
                counter += 1;
                Shape s;
                do
                {
                    s = (Shape) Random.Range(0, System.Enum.GetNames(typeof(Shape)).Length);
                } while (s == shape);

                GameObject dataObject = Instantiate(dataPrefab, this.transform.position, new Quaternion(0, 0, 0, 0), this.transform);

                dataObject.SetActive(true);
                var d = dataObject.GetComponent<Data_Script>();
                d.setShape(s);
                addData(d);
                
                
                if ((counter % spawnSpeed) == 0) // alle 10 counts wird schneller gespawnt
                {   
                    spawnIntervall = spawnIntervall * Random.Range(0.8f, 0.9f);
                    
                }
                if (counter % (2 * spawnSpeed) == 0) lostDataCount += 1;
            }
        }
        this.trySendData();
    }

    
    public Vector3 arangeData(float i)
    {
        float x = 0;
        float y = 0;

        float winkel = (float) (2 * System.Math.PI) / lostDataCount;
      
        winkel = winkel * (float)(i) ;
        

        x = (float)(Vectorlength * (System.Math.Cos(winkel)));
        y = (float)(Vectorlength * (System.Math.Sin(winkel)));
        
        return new Vector3(x,y,0);
    }

    public void rearangeData()
    {
        int i = 0;
        foreach (Data_Script d in daten)
        {
            d.transform.position = this.transform.position + arangeData(i);
            i++;
        }

    }

    public void addData(Data_Script newData)
    {
        daten.Add(newData);
        rearangeData();
    }

    public void removeData(Data_Script data)
    {
        daten.Remove(data);
        rearangeData();
    }

    private void trySendData()
    {
        for(int i = daten.Count - 1; i >= 0; i--)
        {
            var d = daten[i];
            var path = getShortestPathTo(d.shape);
            if (path == null)
            {
                continue;
            }

            if (path.Count == 1)
            {
                var highScore = GameObject.FindGameObjectWithTag("HighScore");
                if (highScore != null)
                {
                    highScore.GetComponent<SetHighScore>().AddPoints(100);
                }
                var money = GameObject.FindGameObjectWithTag("Money");
                if (money != null)
                {
                    money.GetComponent<MoneyScript>().AddMoney(2);
                }
                Destroy(d.gameObject);
                removeData(d);
            }
            else if (path.Count > 1)
            {
                if (path[1].connection.transferData(d, path[1]))
                {
                    removeData(d);
                }
            }
        }
    }

    
}
