using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretInfo : MonoBehaviour {

    public string turretName;
    public float fireRate;
    public int damage;
    public int level;
    public int upgradeCost;
    public int sellCost;

    public int upgradeNumber;

    private Text nameText;
    private Text fireText;
    private Text damageText;
    private Text levelText;
    private Text upgradeText;
    private Text sellText;

    public void SetInfoOn()
    {
        References.instance.InfoOn();
        Invoke("SetNumbers", 0.01f);
    }

    public void SetNumbers()
    {
        nameText = GameObject.Find("Turret Type").GetComponent<Text>();
        fireText = GameObject.Find("Fire Rate Number").GetComponent<Text>();
        damageText = GameObject.Find("Damage Number").GetComponent<Text>();
        if(level > 0)
        {
            levelText = GameObject.Find("Turret Level").GetComponent<Text>();
            levelText.text = "Lvl: " + level;
        }
        else
        {
            levelText = GameObject.Find("Turret Level").GetComponent<Text>();
            levelText.text = "";
        }
        if(upgradeCost > 0)
        {
            upgradeText = GameObject.Find("Upgrade Cost").GetComponent<Text>();
            upgradeText.text = "$" + upgradeCost;
        }
        sellText = GameObject.Find("Sell Price").GetComponent<Text>();

        nameText.text = turretName;
        fireText.text = "" + fireRate;
        damageText.text = "" + damage;
        sellText.text = "$" + sellCost;
    }
}
