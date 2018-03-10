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

    public void Start()
    {
        if (GameObject.FindGameObjectWithTag("Container") != null)
        {
            container = GameObject.FindGameObjectWithTag("Container");
            Lv = container.GetComponent<Containmentscript>().Lv;
            c = this.GetComponentsInChildren<Text>();
            c[1].text = Lv[pos - 1] + "/" + maxLv;

        }
        else
        {

            c = this.GetComponentsInChildren<Text>();
            Lv = new int[22];
        }
    }

    public void onClick()
    {
        explainText = "Cost: " + c[0].text + "\n";
        explainText += "LV: " + c[1].text + "\n";

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

}
