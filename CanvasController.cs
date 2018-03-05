using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    public GameObject gameField;
    public GameObject Highscore;
    public GameObject GameOverCanvas;
    public GameObject MainMenueCanvas;
    public GameObject UpgradeCanvas;

    public bool playing = false;
    public bool gameover = false;
    public bool upgrade = false;
    public bool menue = true;


    // Use this for initialization
    void Start() {
        gameField = GameObject.FindGameObjectWithTag("GameFieldCanvas");
        gameField.SetActive(playing);
        Highscore = GameObject.FindGameObjectWithTag("HighscoreCanvas");
        Highscore.SetActive(playing);
        GameOverCanvas = GameObject.FindGameObjectWithTag("endPanel");
        GameOverCanvas.SetActive(gameover);
        MainMenueCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
        MainMenueCanvas.SetActive(menue);
        UpgradeCanvas = GameObject.FindGameObjectWithTag("UpgradeCanvas");
        UpgradeCanvas.SetActive(upgrade);
    }

    // Update is called once per frame
    void Update() {

    }

    public void play()
    {
         playing = true;
         gameover = false;
         upgrade = false;
         menue = false;
        setCanvas();
    }

    public void gameOver()
    {
        playing = false;
        gameover = true;
        upgrade = false;
        menue = false;
        setCanvas();
        GameObject.FindGameObjectWithTag("NodeSpawner").GetComponent<Knotenspawn>().running = false;

    }

    public void goUpgrade()
    {
        playing = false;
        gameover = false;
        upgrade = true;
        menue = false;
        setCanvas();
    }

    private void setCanvas()
    {
        gameField.SetActive(playing);
        Highscore.SetActive(playing);
        GameOverCanvas.SetActive(gameover);
        MainMenueCanvas.SetActive(menue);
        UpgradeCanvas.SetActive(upgrade);
    }
}



