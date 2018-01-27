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

    public GameObject node;

    

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
                
                
                
                if(Vector2.Distance(go.transform.transform.position, new Vector2(ranX, ranY)) < minDistance)
                {
                    success = false;
                    if (counter == 10)
                    {
                        maxDistance = maxDistance * increasment;
                        counter = 0;
                    }
                        


                    counter++;
                    
                    break;
                }
                


                
                success = true;
            }
            
        }

        Vector2 pos = new Vector2(ranX, ranY);

        
        int i = Random.Range(0, System.Enum.GetNames(typeof(Shape)).Length);

        GameObject newNode = Instantiate(node, pos, new Quaternion(0, 0, 0, 0));
        newNode.GetComponent<NodeDataSpawner>().setShape((Shape)i);

        

        

    }

    
}