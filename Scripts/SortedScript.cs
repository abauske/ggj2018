using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortedScript : MonoBehaviour {

    private bool selected;
    private Containmentscript container;

    // Use this for initialization
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Container").GetComponent<Containmentscript>() != null)
        {
            container = GameObject.FindGameObjectWithTag("Container").GetComponent<Containmentscript>();
        }
        if(container.gameVersion == 1)
        {
            setSorted();
        }
        if (container.gameVersion == 2)
        {
            setRandom();
        }
        if(container.Lv[7] > 0)
        {
            this.GetComponent<Toggle>().enabled = true;
        }
        else
        {
            this.GetComponent<Toggle>().enabled = false;
        }
        
    }

    private void setSorted()
    {
        this.GetComponentInChildren<Text>().text = "Sorted";
        this.GetComponent<Toggle>().isOn = true;
    }
    private void setRandom()
    {
        this.GetComponentInChildren<Text>().text = "Random";
        this.GetComponent<Toggle>().isOn = false;
    }

    public void change()
    {
        if(this.GetComponent<Toggle>().isOn)
        {
            setSorted();
            container.gameVersion = 1;
        }
        else
        {
            setRandom();
            container.gameVersion = 2;
        }
    }

    /*
    // Update is called once per frame
    void Update()
    {
        bool temp = GameObject.FindGameObjectWithTag("GameVersion_sorted").GetComponent<Toggle>().isOn;
        if (temp != selected)
        {
            selected = temp;
            if (temp)
            {
                GameObject.FindGameObjectWithTag("GameVersion_Random").GetComponent<Toggle>().isOn = false;
                var e = GameObject.FindGameObjectWithTag("Container").GetComponent<Containmentscript>();
                if (e != null)
                {
                    e.gameVersion = 1;

                }
            }
            else
            {
                GameObject.FindGameObjectWithTag("GameVersion_Random").GetComponent<Toggle>().isOn = true;
                var e = GameObject.FindGameObjectWithTag("Container").GetComponent<Containmentscript>();
                if (e != null)
                {
                    e.gameVersion = 2;

                }
            }
        }
    }
    */
}
