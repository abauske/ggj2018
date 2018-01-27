using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    private static SynapseButton selected = SynapseButton.DEFAULT;
    public SynapseButton button;

    void FixedUpdate()
    {
        if (button == selected)
        {
            gameObject.GetComponent<Button>().Select();
        }
    }

    public void setDefaultSyn()
    {
        selected = SynapseButton.DEFAULT;
    }
    public void setFastSyn()
    {
        selected = SynapseButton.FAST;
    }
    public void setTriangleSyn()
    {
        selected = SynapseButton.TRIANGLE;
    }
    public void setCircleSyn()
    {
        selected = SynapseButton.CIRCLE;
    }
    public void setSquareSyn()
    {
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