using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour {

    private Button thisButton;
    private ColorBlock colorsButton;

	void Start ()
    {
        Color normal = new Color(1, 1, 1);
        Color highlighted = new Color(0.6549f, 0.6549f, 0.6549f);
        Color pressed = new Color(0.7843f, 0.7843f, 0.7843f);
        Color disabled = new Color(0.7843f, 0.7843f, 0.7843f);

        thisButton = GetComponent<Button>();
        colorsButton = GetComponent<Button>().colors;

        colorsButton.highlightedColor = highlighted;
        colorsButton.normalColor = normal;
        colorsButton.pressedColor = pressed;
        colorsButton.disabledColor = disabled;

        thisButton.colors = colorsButton;
    }
	
}
