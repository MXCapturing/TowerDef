using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class GunUpgrades : MonoBehaviour {

    public int pistolPrice;
    public int pistolLevel;
    public int shotgunPrice;
    public int shotgunLevel;
    public int sniperPrice;
    public int sniperLevel;

    public Button pistolButton;
    public Button shotgunButton;
    public Button sniperButton;

    public GameObject player;

    private void Update()
    {
        if(pistolPrice > Currency.instance.money || pistolLevel == 5)
        {
            pistolButton.interactable = false;
        }
        else
        {
            pistolButton.interactable = true;
        }

        if (shotgunPrice > Currency.instance.money || shotgunLevel == 5)
        {
            shotgunButton.interactable = false;
        }
        else
        {
            shotgunButton.interactable = true;
        }

        if (sniperPrice > Currency.instance.money || sniperLevel == 5)
        {
            sniperButton.interactable = false;
        }
        else
        {
            sniperButton.interactable = true;
        }
    }

    public void PistolUp()
    {
        if(pistolLevel < 4)
        {
            Currency.instance.money -= pistolPrice;
            pistolPrice += 200;
            pistolLevel++;
            BulletNumbers.instance.pistolMaxInGun += 2;
            BulletNumbers.instance.pistolMaxInStock += 6;
            BulletNumbers.instance.pistolDamage += 2;
            BulletNumbers.instance.pistolBulletsInGun = BulletNumbers.instance.pistolMaxInGun;
            if (GameObject.Find("Script Holder").GetComponent<SuppliesRestore>().ammoPrice == 0)
            {
                BulletNumbers.instance.pistolBulletsInStock = BulletNumbers.instance.pistolMaxInStock;
            }
        }
        if(pistolLevel == 4)
        {
            Currency.instance.money -= pistolPrice;
            pistolLevel++;
            player.GetComponent<GunInventory>().gunsIHave.Remove("NewGun_Pistol");
            player.GetComponent<GunInventory>().gunsIHave.Insert(0, "NewGun_Assault");
        }
        Analytics.CustomEvent("Pistol Upgraded", new Dictionary<string, object>
        {
            {"Pistol Level", pistolLevel }
        });
    }

    public void ShotgunUp()
    {
        if (player.GetComponent<GunInventory>().gunsIHave.Contains("NewGun_Shotgun") && shotgunLevel < 5)
        {
            Currency.instance.money -= shotgunPrice;
            shotgunPrice += 300;
            shotgunLevel++;
            BulletNumbers.instance.shotgunMaxInStock += 6;
            BulletNumbers.instance.shotgunMaxInGun += 3;
            BulletNumbers.instance.shotgunDamage += 3;
            BulletNumbers.instance.shotgunBullets += 2;
            BulletNumbers.instance.shotgunBulletsInGun = BulletNumbers.instance.shotgunMaxInGun;
            if (GameObject.Find("Script Holder").GetComponent<SuppliesRestore>().ammoPrice == 0)
            {
                BulletNumbers.instance.shotgunBulletsInStock = BulletNumbers.instance.shotgunMaxInStock;
            }
        }
        else
        {
            player.GetComponent<GunInventory>().gunsIHave.Add("NewGun_Shotgun");
            shotgunLevel = 1;
            shotgunPrice += 300;
        }
        Analytics.CustomEvent("Shotgun Upgraded", new Dictionary<string, object>
        {
            {"Shotgun Level", shotgunLevel }
        });
    }

    public void SniperUp()
    {
        if (player.GetComponent<GunInventory>().gunsIHave.Contains("NewGun_Sniper") && sniperLevel < 5)
        {
            Currency.instance.money -= sniperPrice;
            sniperPrice += 500;
            sniperLevel++;
            BulletNumbers.instance.sniperMaxInStock += 3;
            BulletNumbers.instance.sniperMaxInGun += 1;
            BulletNumbers.instance.sniperDamage += 10;
            BulletNumbers.instance.sniperBulletsInGun = BulletNumbers.instance.sniperMaxInGun;
            if (GameObject.Find("Script Holder").GetComponent<SuppliesRestore>().ammoPrice == 0)
            {
                BulletNumbers.instance.sniperBulletsInStock = BulletNumbers.instance.sniperMaxInStock;
            }
        }
        else
        {
            Currency.instance.money -= sniperPrice;
            player.GetComponent<GunInventory>().gunsIHave.Add("NewGun_Sniper");
            sniperLevel = 1;
            sniperPrice += 500;
        }
        Analytics.CustomEvent("Sniper Upgraded", new Dictionary<string, object>
        {
            {"Sniper Level", sniperLevel }
        });
    }
}
