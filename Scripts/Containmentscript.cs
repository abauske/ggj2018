using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Containmentscript : MonoBehaviour
{
    //Global Variable
    public string[] gameOverText = new string[6];
    public int hardMoney;
    //Game Variablen 
    //global
    public int gameVersion;     //1-2
    public int DataSpawnSpeed;
    public int NodeSpawnSpeed;
    public int maxDataPerNode;      //Startwert: 8, je größer desto besser
    
    //Filip - GameVersion 1 
    public int nEck;            //3-7
    public int density;       //1 - 99, je größer, desto dichter die Nodes
    public float distance;      //2     distanz zw. Ursprung und knoten des ersten nEcks

    //Lukas - GameVersion 2

    public float increasement; //die vergrößerung des maximalen Abstands vom Ursprung;
                               // 1.01 bis max. 1.3
                               // je näher an 1 desto enger spawnen die Knoten
    public float minDistance; // minimaler Abstand der Knoten zueinander
                              // 1.4 bis 3
    public float spawnTime; //zeitlicher Abstand der Knotenspawns
                                //beliebiger Wert grösser Null
    

    //Upgrade Variablen
    public int[] Lv = new int[22];

    //public int nEck;              wird oben verwendet
    //public int NodeSpawnSpeed;
    //public int DataSpawnSpeed;
    //public int maxDataPerNode;
    //public float density;           wird oben Verwendet
    //public int SynapseSpeed;      nur ein UpgradeButton für alle Synapsen, oder je Synapse ein Upgrade button???
    public int StartMoney;
    public float hardMoneyIncrease;
    public float speedCircleMult = 1;
    public float speedSquareMult = 1;
    public float speedTriangleMult = 1;
    public float speedFastMult = 1;
    public float speedDafaultMult = 1;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }



}


