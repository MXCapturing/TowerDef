using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNumbers : MonoBehaviour {

    public static BulletNumbers instance;

    public int pistolBulletsInGun;
    public int pistolBulletsInStock;
    public int pistolMaxInGun;
    public int pistolDamage;

    public int assaultBulletsInGun;
    public int assaultBulletsInStock;
    public int assaultMaxInGun;
    public int assaultDamage;

    public int shotgunBulletsInGun;
    public int shotgunBulletsInStock;
    public int shotgunMaxInGun;
    public int shotgunDamage;
    public int shotgunBullets;
    public float shotgunSpread;

    public int sniperBulletsInGun;
    public int sniperBulletsInStock;
    public int sniperMaxInGun;
    public int sniperDamage;

    private void Awake()
    {
        instance = this;
    }
}
