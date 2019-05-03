using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellorUpgrade : MonoBehaviour {

    public GameObject turretInfo;
    public Button upgrade;
    public GameObject upgradeButton;

    private int upgradeTo;
    public GameObject[] turretNumber;
    private Vector3 turretPos;

    public void Cancel()
    {
        turretInfo.SetActive(false);
        References.instance.turretChosen = null;
    }

    public void Sell()
    {
        turretInfo.SetActive(false);
        Currency.instance.money = Currency.instance.money + References.instance.turretChosen.GetComponent<TurretInfo>().sellCost;
        Destroy(References.instance.turretChosen);
        References.instance.turretChosen = null;
    }

    private void Update()
    {
        if(References.instance.turretChosen != null)
        {
            if (Currency.instance.money >= References.instance.turretChosen.GetComponent<TurretInfo>().upgradeCost)
            {
                upgrade.interactable = true;
            }
            else
            {
                upgrade.interactable = false;
            }

            if(References.instance.turretChosen.GetComponent<TurretInfo>().upgradeCost == 0)
            {
                upgradeButton.SetActive(false);
            }
            else
            {
                upgradeButton.SetActive(true);
            }
        }
    }

    public void Upgrade()
    {
        upgradeTo = References.instance.turretChosen.GetComponent<TurretInfo>().upgradeNumber;
        turretInfo.SetActive(false);
        Currency.instance.money = Currency.instance.money - References.instance.turretChosen.GetComponent<TurretInfo>().upgradeCost;
        turretPos = References.instance.turretChosen.transform.position;
        Destroy(References.instance.turretChosen);
        References.instance.turretChosen = null;
        Instantiate(turretNumber[upgradeTo], turretPos, Quaternion.identity);
    }
}
