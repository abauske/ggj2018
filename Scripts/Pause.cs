using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public void openPause()
    {
        GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("NodeSpawner").GetComponent<Knotenspawn>().pause = true;
        foreach( GameObject ND in GameObject.FindGameObjectsWithTag("Node"))
        {
            ND.GetComponent<NodeDataSpawner>().pause = true;
        }
    }

    public void closePause()
    {
        GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("NodeSpawner").GetComponent<Knotenspawn>().pause = false;
        foreach (GameObject ND in GameObject.FindGameObjectsWithTag("Node"))
        {
            ND.GetComponent<NodeDataSpawner>().pause = false;
        }
    }
}
