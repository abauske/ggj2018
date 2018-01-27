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


    public GameObject parent;


    // Use this for initialization
    void Start()
    {

    }


    public void setParent(GameObject knoten)
    {
        parent = knoten;
        //Instantiate(this, parent.transform);
    }



    public void setShape(Shape s)
    {
        shape = s;
        switch (shape)
        {
            case Shape.TRIANGLE:
                this.GetComponent<Image>().sprite = ImageDreieck; // Dreieck
                break;
            case Shape.SQUARE:
                this.GetComponent<Image>().sprite = ImageViereck; //Viereck
                break;
            case Shape.CIRCLE:
                this.GetComponent<Image>().sprite = ImageKreis; //Kreis
                break;

            default: break;
        }

    }


}
