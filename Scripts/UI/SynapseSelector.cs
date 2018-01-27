using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SynapseSelector : MonoBehaviour
    , IPointerClickHandler // 2
    , IDragHandler
    , IPointerEnterHandler
    , IPointerExitHandler
// ... And many more available!
{

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            print("I was over");
        }
    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        print("I was clicked");
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("I'm being dragged!");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("I'm being dragged!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("I'm being dragged!");
    }
}
