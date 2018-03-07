using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomScript : MonoBehaviour {

    private bool selected;

	// Use this for initialization
	void Start () {
		selected = GameObject.FindGameObjectWithTag("GameVersion_Random").GetComponent<Toggle>().isOn;
    }
	
	// Update is called once per frame
	void Update () {
        bool temp = GameObject.FindGameObjectWithTag("GameVersion_Random").GetComponent<Toggle>().isOn;
        if(temp != selected)
        {
            selected = temp;
            if (temp)
            {
                GameObject.FindGameObjectWithTag("GameVersion_sorted").GetComponent<Toggle>().isOn = false;
                var e = GameObject.FindGameObjectWithTag("Container").GetComponent<Containmentscript>();
                if (e != null)
                {
                    e.gameVersion = 2;

                }
            }
            else
            {
                GameObject.FindGameObjectWithTag("GameVersion_sorted").GetComponent<Toggle>().isOn = true;
                var e = GameObject.FindGameObjectWithTag("Container").GetComponent<Containmentscript>();
                if (e != null)
                {
                    e.gameVersion = 1;

                }
            }
        }
    }
}
