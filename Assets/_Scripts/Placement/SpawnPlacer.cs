using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlacer : MonoBehaviour {

    public GameObject machineGun;
    public GameObject flamethrower;

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
}
