using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreCounter : MonoBehaviour {
    private int Highscore;
    private int Alltime;
    void Increaseby(int points)
    {
        Highscore += points;
        if (Highscore>Alltime)
        {
            Alltime = Highscore;
        }
    }
    private void Update()
    {
        
    }
}
