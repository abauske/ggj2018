using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Knotenspawn : MonoBehaviour
{

    public float centerX = 0f;
    public float centerY = 0f;
    public float increasment = 1.1f;
    public string nodeTag;
    public bool running;
    public GameObject node;
       

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
                if ((ranY<0 && (ranY - 1 < -1 * cam.orthographicSize)) || (ranX<0 && (ranX < -1.8f * cam.orthographicSize)))
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