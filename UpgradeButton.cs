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
        explainText = "Cost: " + c[0].text + "  -  ";
        explainText += "LV: " + c[1].text + "  -  ";
        BuyButton.GetComponent<BuyButton>().selectedButton = this;
        switch(pos)
        {
            case 1:
                explainText += "Limitless\n";
                switch (Lv[pos-1])
                {
                    case 0:
                        explainText +="Increase the Limit for holding Datas per Node. Current Limit: " 
                            + (container.GetComponent<Containmentscript>().maxDataPerNode ).ToString();
                        break;
                    case 1:
                        explainText += "Increase the Limit for holding Datas per Node. Current Limit: "
                           + (container.GetComponent<Containmentscript>().maxDataPerNode).ToString();
                        break;
                    case 2:
                        explainText += "Increase the Limit for holding Datas per Node. Current Limit: "
                           + (container.GetComponent<Containmentscript>().maxDataPerNode).ToString();
                        break;
                    case 3:
                        explainText += "Increase the Limit for holding Datas per Node. Current Limit: "
                           + (container.GetComponent<Containmentscript>().maxDataPerNode).ToString();
                        break;
                    case 4:
                        explainText += "Increase the Limit for holding Datas per Node. Current Limit: "
                           + (container.GetComponent<Containmentscript>().maxDataPerNode).ToString();
                        break;
                    case 5:
                        explainText += "Increase the Limit for holding Datas per Node. Current Limit: "
                           + (container.GetComponent<Containmentscript>().maxDataPerNode).ToString();
                        break;
                    case 6:
                        explainText += "Increase the Limit for holding Datas per Node. Current Limit: "
                           + (container.GetComponent<Containmentscript>().maxDataPerNode).ToString();
                        break;
                    case 7:
                        explainText += "Increase the Limit for holding Datas per Node. Current Limit: "
                           + (container.GetComponent<Containmentscript>().maxDataPerNode).ToString();
                        break;
                    case 8:
                        explainText += "Increase the Limit for holding Datas per Node. Current Limit: "
                           + (container.GetComponent<Containmentscript>().maxDataPerNode).ToString();
                        break;
                    case 9:
                        explainText += "Increase the Limit for holding Datas per Node. Current Limit: "
                           + (container.GetComponent<Containmentscript>().maxDataPerNode).ToString();
                        break;
                    case 10:
                        explainText += "Well, now there is a Limit.";
                        break;
                }
                break;

            case 2:
                explainText += "The Perfect Circle\n";
                switch (Lv[pos - 1])
                {
                    case 0:
                        explainText += "Get closer to pi. Now it`s just Random.";
                        break;
                    case 1:
                        explainText += "Get closer to pi. Now it`s just Triangle.";
                        break;
                    case 2:
                        explainText += "Get closer to pi. Now it`s just Square.";
                        break;
                    case 3:
                        explainText += "Get closer to pi. Now it`s just Pentagon.";
                        break;
                    case 4:
                        explainText += "Get closer to pi. Now it`s just Hexagon.";
                        break;
                    case 5:
                        explainText += "You are now a member of the seven deadly Sins.";
                        break;
                }
                break;

            case 3:
                explainText += "More Nodes = More Data \n";
                switch (Lv[pos - 1])
                {
                    case 0:
                        explainText += "Increase the Chance to place a Node. Increase by +5%";
                        break;
                    case 1:
                        explainText += "Increase the Chance to place a Node. Increase by +5%";
                        break;
                    case 2:
                        explainText += "Increase the Chance to place a Node. Increase by +5%";
                        break;
                    case 3:
                        explainText += "Increase the Chance to place a Node. Increase by +5%";
                        break;
                    case 4:
                        explainText += "Increase the Chance to place a Node. Increase by +5%";
                        break;
                    case 5:
                        explainText += "Increase the Chance to place a Node. Increase by +5%";
                        break;
                    case 6:
                        explainText += "Increase the Chance to place a Node. Increase by +5%";
                        break;
                    case 7:
                        explainText += "Increase the Chance to place a Node. Increase by +5%";
                        break;
                    case 8:
                        explainText += "Increase the Chance to place a Node. Increase by +5%";
                        break;
                    case 9:
                        explainText += "Increase the Chance to place a Node. Increase by +10%";
                        break;
                    case 10:
                        explainText += "Send some Nudes. Hehehe...";
                        break;
                }
                break;

            case 4:
                explainText += "Spawn Nodes faster.\n";
                break;
            case 5:
                explainText += "Spawn Data faster. \n";
                break;
            case 6:
                explainText += "Gain more Money.\n";
                break;
            case 7:
                explainText += "Gain more $$$.\n";
                break;
            default:
                explainText = "";
                break;
        }
        GameObject.FindGameObjectWithTag("ExplainText").GetComponent<Text>().text = explainText;
    }

    public void boughtUpdate()
    {
        if(maxLv <= Lv[pos-1])
        {
            c[1].text = "MAX";
        }
        else
        {
            c[1].text = Lv[pos - 1] + "/" + maxLv;
        }
        //preis muss dann noch erneuert werden
        GameObject.FindGameObjectWithTag("ExplainText").GetComponent<Text>().text = "";
    }

    
}
