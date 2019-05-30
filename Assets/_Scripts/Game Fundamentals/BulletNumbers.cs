using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletNumbers : MonoBehaviour {

    public static BulletNumbers instance;

    public int pistolBulletsInGun;
    public int pistolBulletsInStock;
    public int pistolMaxInStock;
    public int pistolMaxInGun;
    public int pistolDamage;

    public int shotgunBulletsInGun;
    public int shotgunBulletsInStock;
    public int shotgunMaxInStock;
    public int shotgunMaxInGun;
    public int shotgunDamage;
    public int shotgunBullets;
    public float shotgunSpread;

    public int sniperBulletsInGun;
    public int sniperBulletsInStock;
    public int sniperMaxInStock;
    public int sniperMaxInGun;
    public int sniperDamage;

    public Text ammoCount;
    public GunInventory gunInventory;
    public GameObject[] bulletIcons;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        if(instance != this)
        {
            Destroy(this);
        }
    }

    private void FixedUpdate()
    {
        if(gunInventory.gunUsed == GunUsed.Pistol)
        {
            bulletIcons[0].SetActive(true);
            bulletIcons[1].SetActive(false);
            bulletIcons[2].SetActive(false);
            ammoCount.text = pistolBulletsInGun + " / " + pistolBulletsInStock;
        }
        if(gunInventory.gunUsed == GunUsed.Shotgun)
        {
            bulletIcons[0].SetActive(false);
            bulletIcons[1].SetActive(true);
            bulletIcons[2].SetActive(false);
            ammoCount.text = shotgunBulletsInGun + " / " + shotgunBulletsInStock;
        }
        if(gunInventory.gunUsed == GunUsed.Sniper)
        {
            bulletIcons[0].SetActive(false);
            bulletIcons[1].SetActive(false);
            bulletIcons[2].SetActive(true);
            ammoCount.text = sniperBulletsInGun + " / " + sniperBulletsInStock;
        }
    }
}
