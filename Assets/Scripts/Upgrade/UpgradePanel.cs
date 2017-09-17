using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    public Text MoneyText;
    public int Money = 0;
    public List<UpgradeRow> Upgrades = new List<UpgradeRow>();
    public List<string> UpgradeNames = new List<string>();
    public UpgradeSound UpgradeSound;

	// Use this for initialization
	void Start () {
		Money = PlayerPrefs.GetInt("Money", 0);
	    for (int cnt = 0; cnt < Upgrades.Count; cnt++)
	    {
	        Upgrades[cnt].UpgradePanel = this;
	        Upgrades[cnt].OnUpgrade += OnUpgrade;
	        Upgrades[cnt].SetName(UpgradeNames[cnt]);

	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
	    MoneyText.text = "Money: $" + Money;
	}

    void OnUpgrade(UpgradeRow row)
    {

        if (Money >= row.Cost())
        {
            UpgradeSound.PlayBlip(true);
            Money -= row.Cost();
            row.Level++;
            PlayerPrefs.SetInt("Money", Money);
             PlayerPrefs.SetInt(row.UpgradeName, row.Level);
        }
        else
        {
            UpgradeSound.PlayBlip(false);

        }
    }
}
