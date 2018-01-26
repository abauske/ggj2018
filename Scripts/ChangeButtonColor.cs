using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour {

    private Button thisButton;
    private ColorBlock colorsButton;

	void Start ()
    {
        thisButton = GetComponent<Button>();
        colorsButton = GetComponent<Button>().colors;

        colorsButton.highlightedColor = Color.blue;
        colorsButton.normalColor = Color.cyan;
        colorsButton.pressedColor = Color.green;

        thisButton.colors = colorsButton;
    }
	
}
