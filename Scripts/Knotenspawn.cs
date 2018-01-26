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

    private static float maxDistance = 5;

    private GameObject[] nodes;




    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Spawn()
    {
        if (maxDistance == 0)
            maxDistance = 1;

        bool succes = false;
        float ranX = 0;
        float ranY = 0;
        while (!succes)
        {
            ranX = Random.Range(0.1f, maxDistance);
            ranY = Random.Range(0.1f, (float)(System.Math.Sqrt((maxDistance * maxDistance + ranX * ranX))));

            nodes = GameObject.FindGameObjectsWithTag(nodeTag);

            int counter = 0;

            foreach (GameObject go in nodes)
            {
                bool nosuc = true;
                if (GiveDistance(go, ranX, ranY) < minDistance)
                {
                    if (counter == 3)
                        maxDistance = maxDistance * increasment;

                    counter++;
                    nosuc = false;
                }
                if (!nosuc)
                    break;


                counter = 0;
                succes = true;
            }
        }

        Vector2 pos = new Vector2(ranX, ranY);

        int number = (int)Random.Range(0, 3);
        if (number == 3)
            number = 2;

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

    private float GiveDistance(GameObject g, float x, float y)
    {
        Vector2 a = gameObject.transform.transform.position;

        bool equal = a.x == x && a.y == y;

        if (equal)
            return 0;

        float distance = (float)System.Math.Sqrt((a.x - x) * (a.x - x) + (a.y - y) * (a.y - y));


        return distance;
    }
}