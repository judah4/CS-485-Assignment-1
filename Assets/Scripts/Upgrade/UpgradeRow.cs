using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeRow : MonoBehaviour
{

    public int Level = 1;
    public float UpgradeCostMulti = 1.5f;
    public float BaseStartCost = 200;

    public Text UpgradeCostText;
    public Text LevelText;
    public Text NameText;
    public string UpgradeName;
    public event Action<UpgradeRow> OnUpgrade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    UpgradeCostText.text = "Cost: $" + Cost();
	    LevelText.text = "Level: " + Level;
	}

    public int Cost()
    {
        if (Level <= 1)
            return (int)BaseStartCost;

        return (int) (BaseStartCost * (Level - 1) * UpgradeCostMulti);
    }

    public void Upgrade()
    {
        if (OnUpgrade != null)
        {
            OnUpgrade(this);
        }
    }

    public void SetName(string newName)
    {
        UpgradeName = newName;
        NameText.text = newName;
        Level = PlayerPrefs.GetInt(UpgradeName, 1);
    }

}
