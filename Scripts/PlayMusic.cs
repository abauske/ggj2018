using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour {
    AudioSource m_MyAudioSource;
    Shape data;
    public AudioClip fortriangle;
    public AudioClip forcircle;
    public AudioClip forsquare;
    // Use this for initialization
    void Start () {
        m_MyAudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        
    }

    public void PlaySound() {
        switch (data) {
            case Shape.TRIANGLE: m_MyAudioSource.clip = fortriangle; break;
            case Shape.CIRCLE: m_MyAudioSource.clip = forcircle; break;
            case Shape.SQUARE: m_MyAudioSource.clip = forsquare; break;
            default: break;
        }
        if (2 == Random.Range(1, 3)){
            m_MyAudioSource.Play();
        }
	}
}
