using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Filip
public class FastSynapse : Synapse
{

    private readonly float defaultSpeed = 8;

    public override bool canTransfer(Shape data)
    {
        float transferspeed = defaultSpeed * speedFastMult;
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
        float transferspeed = defaultSpeed * speedFastMult;
        float duration = Weight / transferspeed;
        return (Time.time - lastTransmissionStart) / duration;
    }
}
