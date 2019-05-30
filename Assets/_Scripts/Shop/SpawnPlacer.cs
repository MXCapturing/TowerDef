using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlacer : MonoBehaviour {

    public GameObject machineGun;
    public GameObject flamethrower;
    public GameObject rocketlauncher;
    public GameObject landmine;
    public GameObject bearTrap;
    public GameObject fence;

    public int[] prices;
    public Button[] buttons;

    public Text[] priceText;

    private void FixedUpdate()
    {
        if(GamePhases.instance.gamePhases == Phases.Build)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                priceText[i].text = "" + prices[i];
                if (prices[i] <= GameObject.FindGameObjectWithTag("GameController").GetComponent<Currency>().money)
                {
                    buttons[i].interactable = true;
                }
                else
                {
                    buttons[i].interactable = false;
                }
            }
        }
    }

    public void SpawnMachineGun()
    {
        ShopMenu.instance.shopMenu.SetActive(false);
        GameObject mchnGun = Instantiate(machineGun, Vector3.zero, Quaternion.identity);
        mchnGun.GetComponent<TurretPlacer>().price = prices[0];
    }

    public void SpawnFlamethrower()
    {
        ShopMenu.instance.shopMenu.SetActive(false);
        GameObject flmthrower = Instantiate(flamethrower, Vector3.zero, Quaternion.identity);
        flmthrower.GetComponent<TurretPlacer>().price = prices[1];
    }

    public void SpawnRocketLauncher()
    {
        ShopMenu.instance.shopMenu.SetActive(false);
       GameObject rcktLauncher = Instantiate(rocketlauncher, Vector3.zero, Quaternion.identity);
        rcktLauncher.GetComponent<TurretPlacer>().price = prices[2];
    }

    public void SpawnLandMine()
    {
        ShopMenu.instance.shopMenu.SetActive(false);
        GameObject landMine = Instantiate(landmine, Vector3.zero, Quaternion.identity);
        landMine.GetComponent<TrapPlacer>().price = prices[3];
    }

    public void SpawnBearTrap()
    {
        ShopMenu.instance.shopMenu.SetActive(false);
        GameObject bearTarp = Instantiate(bearTrap, Vector3.zero, Quaternion.identity);
        bearTarp.GetComponent<TrapPlacer>().price = prices[4];
    }

    public void SpawnFence()
    {
        ShopMenu.instance.shopMenu.SetActive(false);
        GameObject fancy = Instantiate(fence, Vector3.zero, Quaternion.identity);
        fancy.GetComponent<TrapPlacer>().price = prices[5];
    }
}
