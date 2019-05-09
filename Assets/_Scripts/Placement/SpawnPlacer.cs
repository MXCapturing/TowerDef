using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlacer : MonoBehaviour {

    public GameObject machineGun;
    public GameObject flamethrower;
    public GameObject rocketlauncher;
    public GameObject landmine;
    public GameObject bearTrap;
    public GameObject fence;

    public void SpawnMachineGun()
    {
        ShopMenu.instance.shopMenu.SetActive(false);
        Instantiate(machineGun, Vector3.zero, Quaternion.identity);
    }

    public void SpawnFlamethrower()
    {
        ShopMenu.instance.shopMenu.SetActive(false);
        Instantiate(flamethrower, Vector3.zero, Quaternion.identity);
    }

    public void SpawnRocketLauncher()
    {
        ShopMenu.instance.shopMenu.SetActive(false);
        Instantiate(rocketlauncher, Vector3.zero, Quaternion.identity);
    }

    public void SpawnLandMine()
    {
        ShopMenu.instance.shopMenu.SetActive(false);
        Instantiate(landmine, Vector3.zero, Quaternion.identity);
    }

    public void SpawnBearTrap()
    {
        ShopMenu.instance.shopMenu.SetActive(false);
        Instantiate(bearTrap, Vector3.zero, Quaternion.identity);
    }

    public void SpawnFence()
    {
        ShopMenu.instance.shopMenu.SetActive(false);
        Instantiate(fence, Vector3.zero, Quaternion.identity);
    }
}
