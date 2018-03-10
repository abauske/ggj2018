using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Containmentscript : MonoBehaviour
{
    //Global Variable
    public int hardMoney;
    public string[] gameOverText = new string[6];
    //Game Variablen 
    //global
    public int gameVersion;     //1-2
    public int spawnspeedData;
    public int spawnSpeedNodes;
    public int maxDataPerNode;      //Startwert: 8++
    public int[] Lv = new int[22];
    //Filip
    public int nEck;            //3-7
    public float density;       //1 - 99
    public float distance;      //2
    //Lukas

    


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }



}


