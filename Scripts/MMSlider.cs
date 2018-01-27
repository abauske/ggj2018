using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MMSlider : MonoBehaviour {

    private Slider slider;
    private int min;
    private int max;

    // Use this for initialization
    void Start()
    {
        min = 0;
        max = 100;

        slider = gameObject.GetComponent<Slider>();
        slider.wholeNumbers = true;
        slider.minValue = min;
        slider.maxValue = max;
        slider.value = max / 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
