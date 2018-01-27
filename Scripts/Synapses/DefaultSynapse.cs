using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSynapse : Synapse
{
    public float speedMultiplier = 1;
    private readonly float defaultSpeed = 4;

    private float lastTransmissionStart;

    // Use this for initialization
    void Start()
    {
        base.Start();
        lastTransmissionStart = Time.time;
    }

    public override bool transferData(Data_Script data)
    {
        if (this.canTransfer(data.shape))
        {
            lastTransmissionStart = Time.time;
            var destination = AccessibleNode.gameObject.GetComponent<NodeDataSpawner>();
            destination.addData(data);
            return true;
        }
        return false;
    }

    public override bool canTransfer(Shape data)
    {
        float transferspeed = defaultSpeed / speedMultiplier;
        float duration = Weight / transferspeed;

        if (Time.time > lastTransmissionStart + duration)
        {
            return true;
        }
        Debug.Log("We have to wait: " + (Time.time - lastTransmissionStart - duration));
        return false;
    }
}
