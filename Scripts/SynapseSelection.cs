using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynapseSelection : MonoBehaviour {

    public Type syn = typeof(DefaultSynapse);

    public void setDefaultSyn()
    {
        syn = typeof(DefaultSynapse);
    }
    public void setFastSyn()
    {
        syn = typeof(FastSynapse);
    }
    public void setTriangleSyn()
    {
        syn = typeof(TriangleSynapse);
    }
    public void setCircleSyn()
    {
        syn = typeof(CircleSynapse);
    }
    public void setSquareSyn()
    {
        syn = typeof(SqareSynapse);
    }

}
