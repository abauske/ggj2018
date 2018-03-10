using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtonSettings : MonoBehaviour {

	public void switchPannels(bool b)
    {
        if(b)
        {
            GameObject.FindGameObjectWithTag("UpgradesPanel").GetComponent<RectTransform>().localPosition = new Vector3(8000, 0, 0);
            GameObject.FindGameObjectWithTag("GameSettingPanel").GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            GameObject.FindGameObjectWithTag("ExplainText").GetComponent<Text>().text = "";
        }
        else
        {
            GameObject.FindGameObjectWithTag("UpgradesPanel").GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            GameObject.FindGameObjectWithTag("GameSettingPanel").GetComponent<RectTransform>().localPosition = new Vector3(8000, 0, 0);

        }
    }
}
