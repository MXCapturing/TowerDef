using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretInfo : MonoBehaviour {

    public float fireRate;
    public int damage;
    public int upgradeCost;
    public int sellCost;

    public int upgradeNumber;

    private Text upgradeText;
    private Text sellText;

    public void SetInfoOn()
    {
        References.instance.InfoOn();
    }
}
