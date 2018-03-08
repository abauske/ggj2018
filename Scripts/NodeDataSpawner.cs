using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//Filip
public class NodeDataSpawner : Node {

    public GameObject dataPrefab;
    public GameObject container;
    private List<Data_Script> daten = new List<Data_Script>();      // Liste der Daten, die ein Knoten haelt
    private int lostDataCount;                                  // So viele Daten kann ein Knoten halten, waechst mit der Zeit
    
    private double Vectorlength = 0.5;
    private int counter = 0;                                        // 
    private int spawnSpeed ;                                     // Wie schell mehr Daten spawnen, Die Haeufigkeit wie oft die spawn Geschwindigkeit erhoet wird, kleinere Spawnspeed -> oefters wird SpawnIntervall erniedrigt
    private float spawnTime;                                        
    public float spawnIntervall = 6;                                // In diesm Intervall werden Daten gespawnt, kleineres Intervall -> mehr Daten

    private float looseDelay = 0;                                   // Wie viel Zeit bleibt nachdem ein Knoten ueberlaufen ist
    private Vector3 initialScale;
    public bool destroy = false;
    public bool pause = false;

    // Use this for initialization
    void Start () {
        initialScale = gameObject.transform.localScale;
        container = GameObject.FindGameObjectWithTag("Container");
        if (container != null)
        {
            lostDataCount = container.GetComponent<Containmentscript>().maxDataPerNode;
            spawnSpeed = container.GetComponent<Containmentscript>().spawnspeedData;
        }
        else
        {
            lostDataCount = 8;
            spawnSpeed = 10;
        }
	}

    // Update is called once per frame
    /*
     * -Falls die Menge an der zu haltenden Daten ueberschritten wird, dann ist Game Over
     */
    void Update()
    {
        if (!pause)
        {
            if (daten.Count >= lostDataCount)
            {
                if (looseDelay > 5)
                {

                    GameObject.FindGameObjectWithTag("NodeSpawner").GetComponent<Knotenspawn>().running = false;


                }
                else
                {
                    looseDelay += Time.deltaTime;
                    gameObject.transform.localScale = initialScale * (looseDelay / 10 + 1);
                }
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
                        s = (Shape)Random.Range(0, System.Enum.GetNames(typeof(Shape)).Length);
                    } while (s == shape);

                    // Erzeuge neues Datum
                    GameObject dataObject = Instantiate(dataPrefab, this.transform.position, new Quaternion(0, 0, 0, 0), this.transform);

                    dataObject.SetActive(true);
                    var d = dataObject.GetComponent<Data_Script>();
                    d.setShape(s);
                    addData(d);     // Fuege das Datum in die Liste des Knoten ein

                    if ((counter % spawnSpeed) == 0) // alle 10 counts wird schneller gespawnt
                    {
                        spawnIntervall = spawnIntervall * Random.Range(0.8f, 0.9f);

                    }

                    // Mehr Daten kann der Knoten halten
                    if (counter % (2 * spawnSpeed) == 0)
                    {
                        lostDataCount += 1;
                    }

                    if (looseDelay > 0)
                    {
                        looseDelay -= Time.deltaTime;
                        gameObject.transform.localScale = initialScale * (looseDelay / 10 + 1);
                    }
                    else
                    {
                        gameObject.transform.localScale = initialScale;
                    }
                }
            }
            this.trySendData();
        }
    }

    private void trySendData()
    {
        for (int i = daten.Count - 1; i >= 0; i--)
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
                    highScore.GetComponent<SetHighScore>().AddPoints(1);
                }
                var money = GameObject.FindGameObjectWithTag("Money");
                if (money != null)
                {
                    money.GetComponent<MoneyScript>().AddMoney(2);
                }
                Destroy(d.gameObject);
                removeData(d);
                break;
            }
            else if (path.Count > 1)
            {
                if (path[1].connection.transferData(d, path[1]))
                {
                    removeData(d);
                    break;
                }

                break;
            }
        }
    }


    //setzt die Daten in einem Kreis um den Knoten
    public void rearangeData()
    {
        int i = 0;
        float cirkle = 1f;
        foreach (Data_Script d in daten)
        {
            if (i <= 7) d.transform.position = this.transform.position + arangeData(i, cirkle, 8);
            else if (8 <= i && i < 20)
            {
                cirkle = 1.5f;
                d.transform.position = this.transform.position + arangeData(i, cirkle, 12);
            }
            else if (20 <= i && i < 36)
            {
                cirkle = 2f;
                d.transform.position = this.transform.position + arangeData(i, cirkle, 16);
            }
            else if (36 <= i && i < 52)
            {
                cirkle = 2f;
                d.transform.position = this.transform.position + arangeData(i, cirkle, 16);
            }
            else if (52 <= i && i < 68)
            {
                cirkle = 2f;
                d.transform.position = this.transform.position + arangeData(i, cirkle, 16);
            }
            i++;

        }

    }

    // Positioniert das Datum an der Exakten stelle um den Knoten
    public Vector3 arangeData(float i, float cirkle, int datenAmountOnCirkle)
    {

        float x = 0;
        float y = 0;

        float winkel = (float)(2 * System.Math.PI) / (datenAmountOnCirkle);

        winkel = winkel * (float)(i);


        x = (float)(cirkle * (Vectorlength * (System.Math.Cos(winkel))));
        y = (float)(cirkle * (Vectorlength * (System.Math.Sin(winkel))));

        return new Vector3(x, y, 0);
    }


    //Fuege dem Knoten ein neues Datum ein
    public void addData(Data_Script newData)
    {
        daten.Add(newData);
        newData.gameObject.transform.SetParent(transform);
        rearangeData();
    }

    //Entferne das Datum vom Knoten und loesche es
    public void removeData(Data_Script data)
    {
        daten.Remove(data);
        rearangeData();
    }

  

}
