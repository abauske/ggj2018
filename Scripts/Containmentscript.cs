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
    

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }



}


