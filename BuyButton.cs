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
        if(selectedButton.price <= money.hardMoney 
            && container.Lv[selectedButton.pos - 1] < selectedButton.maxLv)
        {
            money.AddHardMoney(-(selectedButton.price));
            
            switch(selectedButton.pos)
            {
                case 1:
                    print("here");
                    container.Lv[(selectedButton.pos - 1)] += 1;
                    container.maxDataPerNode += 1;
                    break;
                case 2:
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
                    container.Lv[(selectedButton.pos - 1)] += 1;
                    break;
                case 3:
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
                default:
                    break;

            }
            selectedButton.boughtUpdate();
        }
    }
}
