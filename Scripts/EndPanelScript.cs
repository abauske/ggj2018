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
        endText = GetComponentInChildren<Text>();
        var darkage = GetComponent<Image>();
        darkage.enabled = true;
        menuPanel = GameObject.FindGameObjectWithTag("barPanel");
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }

        if (endText != null)
        {
            endText.text = string.Format("You lost!\nYour score:\n{0:00000}", score);
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            child.gameObject.SetActive(true);
        }
    }
}
