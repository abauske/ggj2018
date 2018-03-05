using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Filip
public class MovementController : MonoBehaviour {

    public Vector3 way;
    public float speed;
    public Vector3 finish;
    public Action callback;
    public Synapse synapse;

    private float startTime;

	// Use this for initialization
	void Start ()
	{
        
	    startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    float progress = synapse.getProgress();
        this.transform.position = finish + way * progress;
	    if (progress >= 1)
	    {
            
            callback();
            //gameObject.GetComponent<PlayMusic>().PlaySound();
            Destroy(this);
        }
	        
	}
}
