using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDimmer : MonoBehaviour {
	float t=0;
	public string whatToDo="idle";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (whatToDo == "dimmUp") {
			DimmUp ();
		}
		if (whatToDo == "dimmDown") {
			DimmDown ();
		}
	}
	void DimmUp(){
		t += Time.deltaTime / 1;
		GetComponent<Light>().intensity = Mathf.Lerp (0, 1, t);
	}

	void DimmDown(){
		t += Time.deltaTime / 1;
		GetComponent<Light>().intensity = Mathf.Lerp (1, 0, t);
	}
		
}
