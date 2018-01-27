using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBarButtons : MonoBehaviour {

    private Button thisButton;
    private float height;
    private float width;
    private Canvas canvas;
    	
	void Start ()
    {        
        height = 30;
        
        thisButton = GetComponent<Button>();
        setSize();

        canvas = GetComponent<Canvas>();
	}

    public void Update()
    {
        setSize();
    }

    private void setSize()
    {
        width = Screen.width/8;
        thisButton.image.rectTransform.sizeDelta = new Vector2(width, height);
    }
}
