using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Knotenspawn : MonoBehaviour
{

    public float centerX = 0f;
    public float centerY = 0f;
    public float increasment = 1.1f;
    public string nodeTag;



    public GameObject triangle;
    public GameObject circle;
    public GameObject square;

    public float minDistance;

    public float spawnTime;

    private static float maxDistance = 2;

    private GameObject[] nodes;




    private void Start()
    {
        //Spawn immer nach spawntime ausführen

        InvokeRepeating("Spawn", spawnTime, spawnTime);
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
            ranX = Random.Range(-1 * maxDistance, maxDistance);
            ranY = Random.Range(-1 * (float)(System.Math.Sqrt((maxDistance * maxDistance + ranX * ranX))), (float)(System.Math.Sqrt((maxDistance * maxDistance + ranX * ranX))));

            nodes = GameObject.FindGameObjectsWithTag(nodeTag);

            

            foreach (GameObject go in nodes)
            {
                
                bool nosuc = true;
                
                if(Vector2.Distance(go.transform.transform.position, new Vector2(ranX, ranY)) < minDistance)
                {
                    success = false;
                    if (counter == 10)
                    {
                        maxDistance = maxDistance * increasment;
                        counter = 0;
                    }
                        


                    counter++;
                    nosuc = false;
                    break;
                }
                //if (!nosuc)
                  //  break;


                
                success = true;
            }
            //counter = 0;
        }

        Vector2 pos = new Vector2(ranX, ranY);

        int number = Random.Range(0, 3);


        switch (number)
        {
            case 0:
                Instantiate(triangle, pos, new Quaternion(0, 0, 0, 0));
                break;
            case 1:
                Instantiate(circle, pos, new Quaternion(0, 0, 0, 0));
                break;
            case 2:
                Instantiate(square, pos, new Quaternion(0, 0, 0, 0));
                break;

        }

    }

    
}