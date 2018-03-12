using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverStats : MonoBehaviour {

    private Text[] gameStats;       //0 = EarnedMoney, 1 = Highscore,
                                    //2 = SpawnedNodes, 3 = SpawnedData
                                    //4 = PlayTime, 5 = Reward
    private Containmentscript container;

	// Use this for initialization
	void Start () {
        gameStats = this.GetComponentsInChildren<Text>();
        if(GameObject.FindGameObjectWithTag("Container") != null)
        {
            container = GameObject.FindGameObjectWithTag("Container").GetComponent<Containmentscript>();
        }
        
	}
	
    public void setStatText()
    {
        for(int i = 0; i <container.gameOverText.Length ; i++)
        {
            gameStats[i].text += "\n" + container.gameOverText[i];
        }

    }
}
