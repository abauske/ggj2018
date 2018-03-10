using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {
    private int[] Lv;
    private int thisLv;
    public int pos;         //1,...,22
    public int maxLv;       
    private Text[] c;       //c[0] = Kostenanzeige, c[1] = Lv-Status, c[2] = ErklärungsText
    private string explainText;
    private GameObject container;
    private GameObject BuyButton;
    public int price;

    public void Start()
    {
        BuyButton = GameObject.FindGameObjectWithTag("BuyButton");
        if (GameObject.FindGameObjectWithTag("Container") != null)
        {
            container = GameObject.FindGameObjectWithTag("Container");
            Lv = container.GetComponent<Containmentscript>().Lv;
            c = this.GetComponentsInChildren<Text>();
            c[0].text = price.ToString();
            boughtUpdate();

        }
        else
        {

            c = this.GetComponentsInChildren<Text>();
            Lv = new int[22];
        }
    }

    public void FixedUpdate()
    {
        if(container.GetComponent<Containmentscript>().hardMoney < price)
        {
            c[0].color = Color.red;
        }
        else
        {
            c[0].color = Color.black;
        }
    }

    public void onClick()
    {
        explainText = "Cost: " + c[0].text + "\n";
        explainText += "LV: " + c[1].text + "\n";
        BuyButton.GetComponent<BuyButton>().selectedButton = this;
        switch(pos)
        {
            case 1:
                switch(Lv[pos-1])
                {
                    case 0:
                        explainText += "Button: " + pos + "\nLv Text: " + Lv[pos-1];
                        break;
                    case 1:
                        explainText += "Button: " + pos +"\nLv Text: " + Lv[pos - 1];
                        break;
                    case 2:
                        explainText += "Button: " + pos +"\nLv Text: " + Lv[pos - 1];
                        break;
                    case 3:
                        explainText += "Button: " + pos +"\nLv Text: " + Lv[pos - 1];
                        break;
                    case 4:
                        explainText += "Button: " + pos +"\nLv Text: " + Lv[pos - 1];
                        break;
                    case 5:
                        explainText += "Button: " + pos +"\nLv Text: " + Lv[pos - 1];
                        break;
                    case 6:
                        explainText += "Button: " + pos + "\nLv Text: " + Lv[pos - 1];
                        break;
                }
                break;
            case 2:
                switch (Lv[pos - 1])
                {
                    case 0:
                        explainText += "Button: " + pos + "\nLv Text: " + Lv[pos - 1];
                        break;
                    case 1:
                        explainText += "Button: " + pos + "\nLv Text: " + Lv[pos - 1];
                        break;
                    case 2:
                        explainText += "Button: " + pos + "\nLv Text: " + Lv[pos - 1];
                        break;
                    case 3:
                        explainText += "Button: " + pos + "\nLv Text: " + Lv[pos - 1];
                        break;
                    case 4:
                        explainText += "Button: " + pos + "\nLv Text: " + Lv[pos - 1];
                        break;
                    case 5:
                        explainText += "Button: " + pos + "\nLv Text: " + Lv[pos - 1];
                        break;
                    case 6:
                        explainText += "Button: " + pos + "\nLv Text: " + Lv[pos - 1];
                        break;
                }
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            default:
                explainText += c[2].text;
                break;
        }
        GameObject.FindGameObjectWithTag("ExplainText").GetComponent<Text>().text = explainText;
    }

    public void boughtUpdate()
    {
        c[1].text = Lv[pos - 1] + "/" + maxLv;
        //preis muss dann noch erneuert werden
        GameObject.FindGameObjectWithTag("ExplainText").GetComponent<Text>().text = "";
    }

    
}
