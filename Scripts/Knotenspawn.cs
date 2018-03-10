using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

//Filip
public class Knotenspawn : MonoBehaviour
{
    // Total global Variables
    public string nodeTag; 
    public bool running;
    public GameObject node;
    public float spawnTime;
    private GameObject[] nodes;
    public Camera cam;
    public bool pause = false;
    private int VersionNumer;      //gets from container
    private float startTime;
    private float endTime;
    GameObject container;
    public int spawnedData = 0;

    // Filip-Version Variables , Version Nummer 1

    public float spawnIntervall = 6f;
    public float spawnSpeed = 20f;      //gets from container
    private int PosCounter = 0;
    private int sideCounterMax = 0;
    private int addedEckNodes = 1;

    public float distance;          // gets from container
    private int density;               // gets from container // je größer density, größere chance knoten zu spawnen
    private int totalAmountPlacedNodes = 0;
    private int step = 1;
    private int EckNodeAmount;           //gets from container //max Amount of Ecken
    private Vector3[] EckNodes;

    private Vector3[] direction;
    private int shape = 0;
    private float winkel;

    //Lukas-Version Variables , Version Nummer 2

    public float increasment = 1.1f;
    public bool SideMenuBar = false;
    public float minDistance;
    private static float maxDistance = 2;
    private float timeCounter;


    private void Start()
    {
        container = GameObject.FindGameObjectWithTag("Container");
        startTime = Time.time;

        if (container == null)
        {
            VersionNumer = 1;
            EckNodeAmount = 3;
            density = 50;
            spawnSpeed = 2;
            distance = 2f;
        }
        else
        {
            VersionNumer = container.GetComponent<Containmentscript>().gameVersion;
            EckNodeAmount = container.GetComponent<Containmentscript>().nEck;
            density = container.GetComponent<Containmentscript>().density;
            spawnSpeed = container.GetComponent<Containmentscript>().NodeSpawnSpeed;
            distance = container.GetComponent<Containmentscript>().distance;
        }
        //print("VersionsNummer: " + VersionNumer);
        switch (VersionNumer)
        {
            case 1:  //Filip
                running = true;
                if (EckNodeAmount < 3)
                {
                    EckNodeAmount = 3;
                }
                if (EckNodeAmount > 7)
                {
                    EckNodeAmount = 7;
                }
                winkel = (float)(2 * System.Math.PI / EckNodeAmount);
                EckNodes = new Vector3[EckNodeAmount];
                direction = new Vector3[EckNodeAmount];
                setVectores();
                addedEckNodes = 0;
                break;

            case 2:  //Lukas
                running = true;
                placeNewNode(new Vector3(0, 0, 0));
                break;

            default:
                VersionNumer = 1;
                print("wrong version Nummer");
                break;

        }
    }

    private void setVectores()  //Filip
    {

        for (int i = 0; i < EckNodeAmount; i++)
        {
            float w = i * winkel + (float)(0.5 * System.Math.PI);
            float x = (float)(distance * (System.Math.Cos(w)));
            float y = (float)(distance * (System.Math.Sin(w)));
            EckNodes[i] = new Vector3(x, y, 0);
        }

        for (int i = 0; i < EckNodeAmount; i++)
        {
            int t = (i + 1) % EckNodeAmount;
            direction[i] = EckNodes[t] - EckNodes[i];
        }

    }

    private void placeNewNode(Vector3 position)  //Filip
    {
        GameObject newNode = Instantiate(node, position, new Quaternion(0, 0, 0, 0));
        newNode.SetActive(true);
        shape = totalAmountPlacedNodes % System.Enum.GetNames(typeof(Shape)).Length;
        newNode.GetComponent<NodeDataSpawner>().setShape((Shape)shape);

    }

    private void FixedUpdate()
    {
        if (!pause)
        {
            switch (VersionNumer)
            {
                case 1:  //Filip
                    if (running)
                    {
                        cam.orthographic = true;
                        if (Time.time > spawnTime)
                        {
                            spawnTime = Time.time + 1 + spawnIntervall;
                            if (totalAmountPlacedNodes % spawnSpeed == 0)
                            {
                                spawnIntervall *= Random.Range(0.95f, 0.99f);
                            }
                            if (totalAmountPlacedNodes < 3)
                            {
                                spawnNode(100);
                            }
                            else
                            {
                                spawnNode(density);
                            }

                        }
                    }
                    else
                    {
                        
                        GameObject.FindGameObjectWithTag("GameOverPannel").GetComponent<EndPanelScript>().endGame();
                        nodes = GameObject.FindGameObjectsWithTag(nodeTag);
                        foreach (GameObject killingNode in nodes)
                        {
                            killingNode.GetComponent<NodeDataSpawner>().enabled = false;

                        }
                    }
                    break;

                case 2:  //Lukas
                    timeCounter += Time.deltaTime; // 0.02
                                                   //Spawn immer nach spawntime ausführen

                    if (running)
                    {
                        if ((int)(timeCounter) != 0 && ((int)(timeCounter)) % spawnTime == 0)
                        {
                            Spawn();
                            timeCounter = 0;
                            //InvokeRepeating("Spawn", spawnTime, spawnTime);
                        }

                    }
                    else
                    {
                     
                        GameObject.FindGameObjectWithTag("GameOverPannel").GetComponent<EndPanelScript>().endGame();
                        
                    }

                    cam.orthographic = true;
                    break;

                default:
                    VersionNumer = 1;
                    break;

            }
        }
    }

    public void stopGame(bool stop)
    {
        running = stop;

        container.GetComponent<Containmentscript>().gameOverText[0] = (GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyScript>().Money).ToString();
        container.GetComponent<Containmentscript>().gameOverText[1] = (GameObject.FindGameObjectWithTag("HighScore").GetComponent<SetHighScore>().score).ToString();
        container.GetComponent<Containmentscript>().gameOverText[2] = (totalAmountPlacedNodes).ToString();

        nodes = GameObject.FindGameObjectsWithTag(nodeTag);
        foreach (GameObject killingNode in nodes)
        {
            spawnedData += killingNode.GetComponent<NodeDataSpawner>().counter;
            killingNode.GetComponent<NodeDataSpawner>().enabled = false;

        }
        container.GetComponent<Containmentscript>().gameOverText[3] = (spawnedData).ToString();

        endTime = Time.time;
        int PlayTime = (int)(endTime - startTime);
        string PTs = (PlayTime % 60).ToString() + " s";
        string PTm = ((PlayTime / 60) % 60).ToString() + " min ";
        container.GetComponent<Containmentscript>().gameOverText[4] = PTm + PTs;



        GameObject.FindGameObjectWithTag("GameOverPannel").GetComponentInChildren<GameOverStats>().setStatText();
    }

    private void spawnNode(float dens)  //Filip
    {
        if (dens > Random.Range(1, 100))
        {
            float x = EckNodes[addedEckNodes].x * step + direction[addedEckNodes].x * PosCounter;
            float y = EckNodes[addedEckNodes].y * step + direction[addedEckNodes].y * PosCounter;
            Vector3 position = new Vector3(x, y, 0);
            placeNewNode(position);
            totalAmountPlacedNodes++;
        }

        PosCounter += 1;
        if (PosCounter >= sideCounterMax)
        {
            PosCounter = 0;
            addedEckNodes += 1;
        }

        if (addedEckNodes >= EckNodeAmount)
        {
            addedEckNodes = 0;
            step += 1;
            zoomOut();

            float x1 = EckNodes[addedEckNodes].x * step;
            float y1 = EckNodes[addedEckNodes].y * step;
            Vector3 startNode = new Vector3(x1, y1, 0);

            int i = (addedEckNodes + 1) % EckNodeAmount;
            float x2 = EckNodes[i].x * step;
            float y2 = EckNodes[i].y * step;
            Vector3 zielNode = new Vector3(x2, y2, 0);

            Vector3 sideVector = zielNode - startNode;
            //double laengeSideNode = System.Math.Sqrt( System.Math.Abs( sideVector.x * sideVector.x + sideVector.y * sideVector.y + sideVector.z * sideVector.z) );

            //double directionLaenge = System.Math.Sqrt( System.Math.Abs( direction[0].x * direction[0].x + direction[0].y * direction[0].y + direction[0].z * direction[0].z) );

            sideCounterMax = (int)(sideVector.magnitude / direction[1].magnitude);
        }

    }

    private void zoomOut()  //Filip
    {
        if (step * distance >= cam.orthographicSize)
        {
            cam.orthographicSize += distance;
        }
    }

    private void Spawn()  //Lukas
    {
        if (maxDistance == 0)
            maxDistance = 1;

        bool success = false;
        float ranX = 0;
        float ranY = 0;
        int counter = 0;

        while (!success)
        {
            ranX = Random.Range(-2f * maxDistance, 2f * maxDistance);
            ranY = Random.Range(-1 * (float)(System.Math.Sqrt((maxDistance * maxDistance + ranX * ranX))), (float)(System.Math.Sqrt((maxDistance * maxDistance + ranX * ranX))));

            //if (Vector2.Distance(new Vector2(0, 0), new Vector2(ranX, ranY)) > maxDistance)
            //{
            //    success = false;
            //    counter++;
            //    break;
            //}

            nodes = GameObject.FindGameObjectsWithTag(nodeTag);

            foreach (GameObject go in nodes)
            {
                if (Vector2.Distance(go.transform.transform.position, new Vector2(ranX, ranY)) < minDistance)
                {
                    success = false;
                    if (counter == 10)
                    {
                        maxDistance = maxDistance * increasment;
                        cam.orthographicSize = maxDistance + 3;
                        counter = 0;
                    }

                    counter++;
                    break;
                }

                success = true;
                if (ranY + 1 > cam.orthographicSize || ranX > 1.8f * cam.orthographicSize)
                {
                    success = false;
                }

                if ((ranY < 0 && (ranY - 1 < (-1 * cam.orthographicSize)) || (ranX < 0 && (ranX < -1.8f * cam.orthographicSize))))
                {
                    success = false;
                }

            }

        }

        Vector2 pos = new Vector2(ranX, ranY);

        int i = Random.Range(0, System.Enum.GetNames(typeof(Shape)).Length);

        GameObject newNode = Instantiate(node, pos, new Quaternion(0, 0, 0, 0));
        newNode.GetComponent<NodeDataSpawner>().setShape((Shape)i);

    }

}



    /*  Lukas Version
     * 
     *

    public float centerX = 0f;
    public float centerY = 0f;
    public float increasment = 1.1f;
    public string nodeTag;
    public bool running;
    public GameObject node;
    public bool SideMenuBar = false;


    public float minDistance;

    public float spawnTime;

    private static float maxDistance = 2;

    private GameObject[] nodes;
    
    private float timeCounter;
    
    public Camera cam;

    private void Start()
    {
        running = true;
    }

    private void FixedUpdate()
    {
        timeCounter += Time.deltaTime; // 0.02
        //Spawn immer nach spawntime ausführen
        
        if (running && (int)(timeCounter) != 0 && ((int)(timeCounter)) % spawnTime == 0)
        {
            Spawn();
            timeCounter = 0;
            //InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
        

        cam.orthographic = true;

    }

    private void Spawn()
    {
        if (maxDistance == 0)
            maxDistance = 1;

        bool success = false;
        float ranX = 0;
        float ranY = 0;
        int counter = 0;
        

        while (!success)
        {
            ranX = Random.Range(-2f * maxDistance, 2f * maxDistance);
            ranY = Random.Range(-1  * (float)(System.Math.Sqrt((maxDistance * maxDistance + ranX * ranX))), (float) (System.Math.Sqrt((maxDistance * maxDistance + ranX * ranX))));



            //if (Vector2.Distance(new Vector2(0, 0), new Vector2(ranX, ranY)) > maxDistance)
            //{
            //    success = false;
            //    counter++;
            //    break;
            //}

            nodes = GameObject.FindGameObjectsWithTag(nodeTag);
            

            foreach (GameObject go in nodes)
            {

                if (Vector2.Distance(go.transform.transform.position, new Vector2(ranX, ranY)) < minDistance)
                {
                    success = false;
                    if (counter == 10)
                    {
                        maxDistance = maxDistance * increasment;

                        cam.orthographicSize = maxDistance + 3;

                        counter = 0;
                    }

                    counter++;
                    
                    break;
                }
              
    
                success = true;
                if (ranY + 1 > cam.orthographicSize || ranX > 1.8f * cam.orthographicSize)
                {
                    success = false;
                }

                float bar = GameObject.FindGameObjectWithTag("barPanel").gameObject.GetComponent<RectTransform>().rect.height;
                if (SideMenuBar)
                    bar = 0;



                if ((ranY<0 && (ranY - 1 < (-1 * cam.orthographicSize) + bar) || (ranX<0 && (ranX < -1.8f * cam.orthographicSize))))
                {
                    success = false;
                }



            }

        }
         
        Vector2 pos = new Vector2(ranX, ranY);

        
        int i = Random.Range(0, System.Enum.GetNames(typeof(Shape)).Length);

        GameObject newNode = Instantiate(node, pos, new Quaternion(0, 0, 0, 0));
        newNode.GetComponent<NodeDataSpawner>().setShape((Shape)i);

        
    }

    */




