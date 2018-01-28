using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastSynapse : Synapse
{

    public float speedMultiplier = 2;
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

    public override float getProgress()
    {
        float transferspeed = defaultSpeed * speedMultiplier;
        float duration = Weight / transferspeed;
        return (Time.time - lastTransmissionStart) / duration;
    }
}
