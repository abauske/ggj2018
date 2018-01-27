using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour {
    public int Money;
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
        MoneyText.text = string.Format("Money:\n{0:00000}", Money, "$");
    }
}
