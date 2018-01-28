using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    private static SynapseButton selected = SynapseButton.DEFAULT;
    public SynapseButton button;
    public Image selecor;

    void FixedUpdate()
    {
        print(selected);
        if (button == selected)
        {
            gameObject.GetComponent<Button>().Select();
            selecor.color = Color.white;
        }
        else
        {
            selecor.color = Color.black;
        }
    }

    public void setDefaultSyn()
    {
        print("set default");
        selected = SynapseButton.DEFAULT;
    }
    public void setFastSyn()
    {
        print("set FAST");
        selected = SynapseButton.FAST;
    }
    public void setTriangleSyn()
    {
        print("set TRIANGLE");
        selected = SynapseButton.TRIANGLE;
    }
    public void setCircleSyn()
    {
        print("set CIRCLE");
        selected = SynapseButton.CIRCLE;
    }
    public void setSquareSyn()
    {
        print("set SQUARE");
        selected = SynapseButton.SQUARE;
    }
}

public enum SynapseButton
{
    DEFAULT,
    FAST,
    SQUARE,
    TRIANGLE,
    CIRCLE
}