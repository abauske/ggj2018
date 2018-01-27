using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenuScript : MonoBehaviour {

    RectTransform canvas;
    RectTransform label;
    Vector3 startingPosition;

    private float speedIn;
    private float speedOut;
    private bool inMove;
    private bool outMove;
    private float xEnd;

    private void Start()
    {
        label = gameObject.GetComponent<RectTransform>();
        canvas = GameObject.Find("EscapeCanvas").GetComponent<RectTransform>();
        startingPosition = new Vector3(-(label.rect.xMax), Screen.height, 0);
        speedIn = 10f;
        speedOut = -10f;
        xEnd = label.rect.xMax;
        label.position = startingPosition;
    }

    public void moveIn()
    {
        inMove = true;
        label.position = startingPosition;
    }

    public void moveOut()
    {
        outMove = true;
        speedOut = -10f;
    }

    private void FixedUpdate()
    {
        if (inMove && label.rect.xMin < 0)
        {
            if(label.position.x > startingPosition.x*0.2)
            {
                speedIn *= 0.65f;
            }

            transform.Translate(speedIn, 0f, 0f);
            if (label.position.x < xEnd)
                transform.position = new Vector3(label.position.x + speedIn, startingPosition.y, startingPosition.z);
        }

        if(label.position.x + label.rect.xMax < 0.1 || outMove)
        {
            inMove = false;
            speedIn = 10f;
        }

        if(outMove && label.rect.xMax > 0)
        {
            transform.Translate(speedOut, 0f, 0f);
            transform.position = new Vector3(label.position.x + speedOut, startingPosition.y, startingPosition.z);
        }

        if(label.rect.xMax < 0 || inMove)
        {
            outMove = false;
            speedOut = -10f;
        }
    }
}
