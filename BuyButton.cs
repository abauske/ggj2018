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
            container.Lv[selectedButton.pos - 1] += 1;
            selectedButton.boughtUpdate();
        }
    }
}
