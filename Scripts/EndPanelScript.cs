using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Filip
public class EndPanelScript : MonoBehaviour {

    
    public void endGame()
    {
        GameObject.FindGameObjectWithTag("GameOverPannel").GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("GameFieldCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("HighscoreCanvas").GetComponent<Canvas>().enabled = false;
    }

 

    /* Simon Version
    *
    public void endGame()
    {
        if (ended)
        {
            return;
        }
        endText = GetComponentInChildren<Text>();
        mainMenuButton = GetComponentInChildren<Button>(true);
        retryButton = GetComponentInChildren<Button>(true);
        var scoreObj = GameObject.FindGameObjectWithTag("HighScore");

        if (endText != null && scoreObj != null && scoreObj.GetComponent<SetHighScore>() != null)
        {
            score = scoreObj.GetComponent<SetHighScore>().score;
        }
        var darkage = GetComponent<Image>();
        darkage.enabled = true;
        menuPanel = GameObject.FindGameObjectWithTag("barPanel");
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            child.gameObject.SetActive(true);
        }

        ended = true;
    }

    public bool isEnded()
    {
        return ended;
    }
    *
    */


}
