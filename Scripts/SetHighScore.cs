using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHighScore : MonoBehaviour {

    public double score;

    public Text scoreText;

	// Use this for initialization
	void Start ()
    {
        score = 50;
        scoreText = GetComponent<Text>();
        setHighScoreText();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        score += Time.deltaTime;
        setHighScoreText();
	}

    void setHighScoreText()
    {
        scoreText.text = string.Format("Highscore:\n{0:00000}", score);
    }
}
