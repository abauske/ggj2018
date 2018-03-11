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
                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
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
                    break;

                case 11: //DataSpawnSpeed
                    break;

                case 12: //More Money in Game
                    break;

                case 13: //More Hard Money in Updates
                    break;

                default:
                    break;

            }
            selectedButton.boughtUpdate();
        }
    }
}
