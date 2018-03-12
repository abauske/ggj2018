using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Filip
public class CircleSynapse : Synapse {


    private float defaultSpeed = 8;

    public Shape transferable = Shape.CIRCLE;

    public override bool canTransfer(Shape data)
    {
        float transferspeed = defaultSpeed * speedCircleMult;
        float duration = Weight / transferspeed;

        if (data == transferable && Time.time > lastTransmissionStart + duration)
        {
            return true;
        }
        //Debug.Log("We have to wait: " + (Time.time - lastTransmissionStart - duration));
        return false;
    }

    public override float getProgress()
    {
        float transferspeed = defaultSpeed * speedCircleMult;
        float duration = Weight / transferspeed;
        return (Time.time - lastTransmissionStart) / duration;
    }
}
