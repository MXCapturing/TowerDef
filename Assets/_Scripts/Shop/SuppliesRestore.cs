using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuppliesRestore : MonoBehaviour {

    public int ammoPrice;
    public int hpPrice;
    public int doorPrice;
    public int armourPrice;

    public Button ammoButton;
    public Button hpButton;
    public Button doorButton;
    public Button armourButton;

    private BulletNumbers bulletNo;
    public GameObject player;

    private void Start()
    {
        bulletNo = BulletNumbers.instance;
    }
    private void FixedUpdate()
    {
        hpPrice = 5 * (player.GetComponent<PlayerHP>().maxHP - player.GetComponent<PlayerHP>().health);
        ammoPrice = (2 * (bulletNo.pistolMaxInStock - bulletNo.pistolBulletsInStock) + (5 * (bulletNo.shotgunMaxInStock - bulletNo.shotgunBulletsInStock)) + (10 * (bulletNo.sniperMaxInStock - bulletNo.sniperBulletsInStock)));

        if(ammoPrice > Currency.instance.money || ammoPrice == 0)
        {
            ammoButton.interactable = false;
        }
        else
        {
            ammoButton.interactable = true;
        }

        if (hpPrice > Currency.instance.money || hpPrice == 0)
        {
            hpButton.interactable = false;
        }
        else
        {
            hpButton.interactable = true;
        }

        if (doorPrice > Currency.instance.money || doorPrice == 0)
        {
            doorButton.interactable = false;
        }
        else
        {
            doorButton.interactable = true;
        }

        if (armourPrice > Currency.instance.money || player.GetComponent<PlayerHP>().armour == player.GetComponent<PlayerHP>().maxArmour)
        {
            armourButton.interactable = false;
        }
        else
        {
            armourButton.interactable = true;
        }
    }

    public void RefillAmmo()
    {
        Currency.instance.money -= ammoPrice;
        bulletNo.pistolBulletsInStock = bulletNo.pistolMaxInStock;
        bulletNo.shotgunBulletsInStock = bulletNo.shotgunMaxInStock;
        bulletNo.sniperBulletsInStock = bulletNo.sniperMaxInStock;
    }

    public void RefillHealth()
    {
        Currency.instance.money -= hpPrice;
        player.GetComponent<PlayerHP>().health = player.GetComponent<PlayerHP>().maxHP;
    }

    public void FixDoors()
    {
        Currency.instance.money -= doorPrice;
        for (int i = 0; i < gameObject.GetComponent<DoorUpgrade>().doors.Count; i++)
        {
            gameObject.GetComponent<DoorUpgrade>().doors[i].GetComponent<DoorHealth>().health = gameObject.GetComponent<DoorUpgrade>().doors[i].GetComponent<DoorHealth>().maxHP;
        }
    }

    public void Armour()
    {
        Currency.instance.money -= armourPrice;
        player.GetComponent<PlayerHP>().armour = player.GetComponent<PlayerHP>().maxArmour;
    }
}
