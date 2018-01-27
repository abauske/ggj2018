using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSynapse : Synapse
{
    public float speedMultiplier = 1;
    private readonly float defaultSpeed = 4;

    public override bool canTransfer(Shape data)
    {
        float transferspeed = defaultSpeed * speedMultiplier;
        float duration = Weight / transferspeed;

        if (Time.time > lastTransmissionStart + duration)
        {
//            Debug.Log("send");
            return true;
        }
//        Debug.Log("We have to wait: " + (Time.time - lastTransmissionStart - duration));
        return false;
    }
}
