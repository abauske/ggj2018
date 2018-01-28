using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public Vector3 way;
    public float speed;
    public Vector3 finish;
    public Action callback;

    private float startTime;

	// Use this for initialization
	void Start ()
	{
	    startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = transform.position + Vector3.Normalize(way) * speed * Time.deltaTime;
	    if (Time.time >= startTime + Vector3.Distance(way, Vector3.zero) / speed)
	    {
	        callback();
            Destroy(this);
        }
	        
	}
}
