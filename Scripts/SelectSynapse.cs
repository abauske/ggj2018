using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSynapse : MonoBehaviour {

   
    private Synapse syn;

    private void Start()
    {
        syn = GetComponent<Synapse>();
    }

    public void selectSynapse(Shape type)
    {
        
    }
}
