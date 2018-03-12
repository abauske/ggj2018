using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour {

    public UpgradeButton selectedButton;
    public Containmentscript container;
    public MoneyScript money;

	// Use this for initialization
	void Start () {
        container = GameObject.FindGameObjectWithTag("Container").GetComponent<Containmentscript>();
        money = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clickBuy()
    {
        if((selectedButton.price * (container.Lv[selectedButton.pos-1]+1)) <= money.hardMoney 
            && container.Lv[selectedButton.pos - 1] < selectedButton.maxLv)
        {
            money.AddHardMoney(-(selectedButton.price * (container.Lv[selectedButton.pos - 1]+1)));
            
            switch(selectedButton.pos)
            {
                case 1: //speed Mult. Default
                    print("speedNormal");
                    container.speedDafaultMult += 0.1f;
                    container.Lv[(selectedButton.pos - 1)] += 1;
                    break;

                case 2: //speed Mult. circle
                    print("speedCircle");
                    container.speedCircleMult += 0.1f;
                    container.Lv[(selectedButton.pos - 1)] += 1;
                    break;

                case 3: //speed Mult. square
                    print("speedSquare");
                    container.speedSquareMult += 0.1f;
                    container.Lv[(selectedButton.pos - 1)] += 1;
                    break;

                case 4: //speed Mult. Triangle
                    print("speedTriangle");
                    container.speedTriangleMult += 0.1f;
                    container.Lv[(selectedButton.pos - 1)] += 1;
                    break;

                case 5: //speed Mult. Fast
                    print("speedFast");
                    container.speedFastMult += 0.1f;
                    container.Lv[(selectedButton.pos - 1)] += 1;
                    break;

                case 6:
                    break;

                case 7: //Data per Node
                    print("here");
                    container.Lv[(selectedButton.pos - 1)] += 1;
                    container.maxDataPerNode += 1;
                    break;

                case 8: //nEck
                    print("here2");
                    if (container.Lv[(selectedButton.pos - 1)] == 0)
                    {
                        container.gameVersion = 2;
                        //Tag enablen um zw. Gameversionen zu wechseln;
                    }
                    else
                    {
                        container.nEck += 1;
                    }
                    if (container.Lv[selectedButton.pos - 1] == 0)
                    {
                        Toggle[] g = GameObject.FindGameObjectWithTag("GameSettingPanel").GetComponentsInChildren<Toggle>();
                        g[0].enabled = true;
                    }
                    container.Lv[(selectedButton.pos - 1)] += 1;
                    break;

                case 9: //Density
                    print("here3");
                    if(container.Lv[(selectedButton.pos - 1)] == 9)
                    {
                        container.density += 10;
                    }
                    else
                    {
                        container.density += 5;
                    }
                    container.Lv[(selectedButton.pos - 1)] += 1;
                    break;

                case 10: //NodeSpawnSpeed
                   if((container.Lv[(selectedButton.pos-1)]+1) %3 == 0)
                    {
                        container.NodeSpawnSpeed += 1;

                    }
                    container.spawnIntervall += 0.4f;
                    container.Lv[(selectedButton.pos - 1)] += 1;
                    break;

                case 11: //DataSpawnSpeed
                    break;

                case 12: //More Money in Game Start
                    container.StartMoney += 5;
                    container.Lv[(selectedButton.pos - 1)] += 1;
                    break;

                case 13: //More Hard Money in Updates
                    container.hardMoneyIncrease += 10;
                    container.Lv[(selectedButton.pos - 1)] += 1;
                    break;

                default:
                    break;

            }
            selectedButton.boughtUpdate();
        }
    }
}
