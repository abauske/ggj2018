using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Filip
public class BackGroundScript : MonoBehaviour {

    Image imageComp;
    public Sprite backSprite;

    void Start()
    {
        imageComp = GetComponent<Image>();
        if (imageComp)
        {
            imageComp.sprite = backSprite;
        }
    }
}
