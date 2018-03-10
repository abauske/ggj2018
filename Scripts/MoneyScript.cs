using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Filip
public class MoneyScript : MonoBehaviour {
    public int Money = 25;
    public int hardMoney;
    private Text MoneyText;
    private Containmentscript container;
    // Use this for initialization
    void Start () {
        container = GameObject.FindGameObjectWithTag("Container").GetComponent<Containmentscript>();
        MoneyText = GetComponent<Text>();
        this.hardMoney = container.hardMoney;
        if(SceneManager.GetSceneByName("Upgrades") == SceneManager.GetActiveScene())
        {
            setHardMoney();
        }
        if (SceneManager.GetSceneByName("SynaptX2_0") == SceneManager.GetActiveScene())
        {
            setMoneyText();
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetSceneByName("Upgrades") == SceneManager.GetActiveScene())
        {
            setHardMoney();
        }
        if (SceneManager.GetSceneByName("SynaptX2_0") == SceneManager.GetActiveScene())
        {
            setMoneyText();
        }
    }

    public void AddMoney(int bymoney)
    {
        Money += bymoney;
    }

    void setMoneyText()
    {
        MoneyText.text = "Money: " + "\n" +  Money.ToString();
    }

    public void setHardMoney()
    {
        MoneyText.text = hardMoney.ToString() + "$";
    }

    public void AddHardMoney(int m)
    {
        hardMoney += m;
        setHardMoney();
        container.hardMoney += m;
    }
}
