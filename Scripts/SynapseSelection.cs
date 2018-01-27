using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynapseSelection : MonoBehaviour {

    public Type syn = typeof(DefaultSynapse);
    public int price = 20;

    public void setDefaultSyn()
    {
        syn = typeof(DefaultSynapse);
        price = 20;
    }
    public void setFastSyn()
    {
        syn = typeof(FastSynapse);
        price = 60;
    }
    public void setTriangleSyn()
    {
        syn = typeof(TriangleSynapse);
        price = 30;
    }
    public void setCircleSyn()
    {
        syn = typeof(CircleSynapse);
        price = 30;
    }
    public void setSquareSyn()
    {
        syn = typeof(SqareSynapse);
        price = 30;
    }

}
