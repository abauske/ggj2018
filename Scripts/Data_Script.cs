using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data_Script : MonoBehaviour
{
    private Shape shape;
    public Sprite ImageDreieck;
    public Sprite ImageViereck;
    public Sprite ImageKreis;

    
    // Use this for initialization
    void Start()
    {

    }

    
    public void setShape(Shape s)
    {
        shape = s;
        switch (shape)
        {
            case Shape.TRIANGLE:
                this.GetComponent<SpriteRenderer>().sprite = ImageDreieck; // Dreieck
                break;
            case Shape.SQUARE:
                this.GetComponent<SpriteRenderer>().sprite = ImageViereck; //Viereck
                break;
            case Shape.CIRCLE:
                this.GetComponent<SpriteRenderer>().sprite = ImageKreis; //Kreis
                break;

            default: break;
        }

    }


}
