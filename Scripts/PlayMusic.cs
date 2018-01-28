using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour {
    AudioSource m_MyAudioSource;
    GameObject myNode;
    Shape data;
    public AudioClip fortriangle;
    public AudioClip forcircle;
    public AudioClip forsquare;
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

    public void PlaySound() {
        switch (data) {
            case Shape.TRIANGLE: m_MyAudioSource.clip = fortriangle; break;
            case Shape.CIRCLE: m_MyAudioSource.clip = forcircle; break;
            case Shape.SQUARE: m_MyAudioSource.clip = forsquare; break;
            default: break;
        }
       
         float posx = myNode.transform.position.x;
        m_MyAudioSource.pitch = 1 + posx * 0.05f;
        m_MyAudioSource.Play();
      
	}
}
