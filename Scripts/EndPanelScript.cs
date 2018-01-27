using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPanelScript : MonoBehaviour {
    
    public int score;

    private Text endText;
    private GameObject endPanel;
    private GameObject menuPanel;

    public void endGame()
    {
        endText = GetComponent<Text>();
        endPanel = GetComponent<GameObject>();
        menuPanel = GameObject.Find("barPanel");
        endPanel.SetActive(true);
        menuPanel.SetActive(false);
        endText.text = string.Format("You lost!\nYour score:\n{0:00000}", score);
    }
}
