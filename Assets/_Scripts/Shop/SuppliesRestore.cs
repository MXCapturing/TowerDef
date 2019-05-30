using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuppliesRestore : MonoBehaviour {

    public int ammoPrice;
    public GameObject ammoMax;
    public int hpPrice;
    public GameObject hpMax;
    public int doorPrice;
    public GameObject doorMax;
    public int armourPrice;
    public GameObject armourMax;

    public Text ammoText;
    public Text hpText;
    public Text doorText;
    public Text armourText;

    public Button ammoButton;
    public Button hpButton;
    public Button doorButton;
    public Button armourButton;

    private BulletNumbers bulletNo;
    public GameObject player;

    public GameObject[] doors;
    public Image[] doorHP;

    private void Start()
    {
        bulletNo = BulletNumbers.instance;
    }
    private void FixedUpdate()
    {
        hpPrice = Mathf.RoundToInt(5 * (player.GetComponent<PlayerHP>().maxHP - player.GetComponent<PlayerHP>().health));
        ammoPrice = (2 * (bulletNo.pistolMaxInStock - bulletNo.pistolBulletsInStock) + (5 * (bulletNo.shotgunMaxInStock - bulletNo.shotgunBulletsInStock)) + (10 * (bulletNo.sniperMaxInStock - bulletNo.sniperBulletsInStock)));

        ammoText.text = "" + ammoPrice;
        hpText.text = "" + hpPrice;
        doorText.text = "" + doorPrice;
        armourText.text = "" + armourPrice;

        if(ammoPrice > Currency.instance.money || ammoPrice == 0)
        {
            ammoButton.interactable = false;
        }
        else
        {
            ammoButton.interactable = true;
        }
        if(ammoPrice == 0)
        {
            ammoMax.SetActive(true);
        }
        else
        {
            ammoMax.SetActive(false);
        }

        if (hpPrice > Currency.instance.money || hpPrice == 0)
        {
            hpButton.interactable = false;
        }
        else
        {
            hpButton.interactable = true;
        }
        if(hpPrice == 0)
        {
            hpMax.SetActive(true);
        }
        else
        {
            hpMax.SetActive(false);
        }

        if (doorPrice > Currency.instance.money || DoorMaxHP() == true)
        {
            doorButton.interactable = false;
        }
        else
        {
            doorButton.interactable = true;
        }
        if(DoorMaxHP() == true)
        {
            doorMax.SetActive(true);
        }
        else
        {
            doorMax.SetActive(false);
        }

        if (armourPrice > Currency.instance.money || player.GetComponent<PlayerHP>().armour == player.GetComponent<PlayerHP>().maxArmour)
        {
            armourButton.interactable = false;
        }
        else
        {
            armourButton.interactable = true;
        }
        if(player.GetComponent<PlayerHP>().armour == player.GetComponent<PlayerHP>().maxArmour)
        {
            armourMax.SetActive(true);
        }
        else
        {
            armourMax.SetActive(false);
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
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].GetComponent<DoorHealth>().health = doors[i].GetComponent<DoorHealth>().maxHP;
        }
    }

    public void Armour()
    {
        Currency.instance.money -= armourPrice;
        player.GetComponent<PlayerHP>().armour = player.GetComponent<PlayerHP>().maxArmour;
    }

    private bool DoorMaxHP()
    {
        for (int i = 0; i < doorHP.Length; i++)
        {
            if(doorHP[i].fillAmount < 1)
            {
                return false;
            }
        }
        return true;
    }
}
