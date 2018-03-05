using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Filip
public class SetHighScore : MonoBehaviour {

    public int score;

    private Text scoreText;

	// Use this for initialization
	void Start ()
    {

        scoreText = GetComponent<Text>();
        setHighScoreText();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        setHighScoreText();
	}

    public void AddPoints(int points)
    {

        score += points;
    }

    void setHighScoreText()
    {
        scoreText.text = string.Format("Highscore:\n{0:00000}", score);
    }
}
