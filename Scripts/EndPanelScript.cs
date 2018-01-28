using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPanelScript : MonoBehaviour {
    
    public float score;

    private Text endText;
    private GameObject endPanel;
    private GameObject menuPanel;
    private Button mainMenuButton;
    private Button retryButton;

    public void endGame()
    {
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
    }
}
