using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuppliesRestore : MonoBehaviour {

    public int ammoPrice;
    public int hpPrice;
    public int doorPrice;

    public Button ammoButton;
    public Button hpButton;
    public Button doorButton;

    private BulletNumbers bulletNo;
    public GameObject player;

    private void Start()
    {
        bulletNo = BulletNumbers.instance;
    }
    private void FixedUpdate()
    {
        hpPrice = 5 * (player.GetComponent<PlayerHP>().maxHP - player.GetComponent<PlayerHP>().health);
        ammoPrice = (1 * (bulletNo.pistolMaxInStock - bulletNo.pistolBulletsInStock) + (3 * (bulletNo.shotgunMaxInStock - bulletNo.shotgunBulletsInStock)) + (5 * (bulletNo.sniperMaxInStock - bulletNo.sniperBulletsInStock)));

        if(ammoPrice >= Currency.instance.money || ammoPrice == 0)
        {
            ammoButton.interactable = false;
        }
        else
        {
            ammoButton.interactable = true;
        }

        if (hpPrice >= Currency.instance.money || hpPrice == 0)
        {
            hpButton.interactable = false;
        }
        else
        {
            hpButton.interactable = true;
        }

        if (doorPrice >= Currency.instance.money || doorPrice == 0)
        {
            doorButton.interactable = false;
        }
        else
        {
            doorButton.interactable = true;
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

    }
}
