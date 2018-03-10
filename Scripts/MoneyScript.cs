using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Filip
public class MoneyScript : MonoBehaviour {
    public int Money = 25;
    private Text MoneyText;
    // Use this for initialization
    void Start () {
        MoneyText = GetComponent<Text>();
        setMoneyText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        setMoneyText();
    }

    public void AddMoney(int bymoney)
    {
        Money += bymoney;
    }

    void setMoneyText()
    {
        MoneyText.text = "Money: " + "\n" +  Money.ToString();
    }
}
