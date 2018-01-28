using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
