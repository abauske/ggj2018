using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour {
    AudioSource m_MyAudioSource;
    GameObject myNode;
	// Use this for initialization
	void Start () {
        m_MyAudioSource = GetComponent<AudioSource>();
        myNode = this.gameObject;
    }
    private void Update()
    {
        float posx = myNode.transform.position.x;
        Debug.Log(posx);
        if (Input.GetKeyDown("return"))
        {
            PlaySound();
        }
    }
    
    void PlaySound() {
        float posx=myNode.transform.position.x;
        m_MyAudioSource.pitch = 1+posx*0.05f;
        m_MyAudioSource.Play();
        
	}
}
