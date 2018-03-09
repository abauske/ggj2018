using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {
    private int[] Lv;
    private int thisLv;
    private Text[] c;
    private string explainText;

    public void Start()
    {
        Lv = GameObject.FindGameObjectWithTag("Container").GetComponent<Containmentscript>().Lv;
        thisLv = Lv[0];
    }

    public void onClick()
    {
        c = this.GetComponentsInChildren<Text>();
        explainText = "Cost: " + c[0].text + "\n";
        explainText += "LV: " + thisLv + c[1].text + "\n";
        explainText += c[2].text;
        GameObject.FindGameObjectWithTag("ExplainText").GetComponent<Text>().text = explainText;
    }

}
