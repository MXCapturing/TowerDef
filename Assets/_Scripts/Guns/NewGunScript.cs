using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NewGunStyles
{
    pistol, assault, shotgun, sniper
}

public class NewGunScript : MonoBehaviour {

    public NewGunStyles currentStyle;

    [Header("Bullet properties")]
    [Tooltip("Preset value to tell with how many bullets will our waepon spawn aside.")]
    public int bulletsIHave;
    [Tooltip("Preset value to tell with how much bullets will our waepon spawn inside rifle.")]
    public int bulletsInTheGun;
    [Tooltip("Preset value to tell how much bullets can one magazine carry.")]
    public int amountOfBulletsPerLoad;

    public MouseLookScript mls;

    private PlayerMovementScript pmS;
    private BulletNumbers bulletSets;

    public int damage;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (EnemyWaves.instance.state != EnemyWaves.SpawnState.Shopping)
        {
            if (currentStyle == NewGunStyles.pistol || currentStyle == NewGunStyles.assault)
            {
                BulletNumbers.instance.pistolBulletsInGun = bulletsInTheGun;
                BulletNumbers.instance.pistolBulletsInStock = bulletsIHave;
            }
            if (currentStyle == NewGunStyles.shotgun)
            {
                BulletNumbers.instance.shotgunBulletsInGun = bulletsInTheGun;
                BulletNumbers.instance.shotgunBulletsInStock = bulletsIHave;
            }
            if (currentStyle == NewGunStyles.sniper)
            {
                BulletNumbers.instance.sniperBulletsInGun = bulletsInTheGun;
                BulletNumbers.instance.sniperBulletsInStock = bulletsIHave;
            }
        }

    }

    public void SetStats()
    {
        if (currentStyle == NewGunStyles.pistol)
        {
            bulletsInTheGun = bulletSets.pistolBulletsInGun;
            bulletsIHave = bulletSets.pistolBulletsInStock;
            amountOfBulletsPerLoad = bulletSets.pistolMaxInGun;
            damage = bulletSets.pistolDamage;
        }
        if (currentStyle == NewGunStyles.assault)
        {
            bulletsInTheGun = bulletSets.pistolBulletsInGun;
            bulletsIHave = bulletSets.pistolBulletsInStock;
            amountOfBulletsPerLoad = bulletSets.pistolMaxInGun;
            damage = bulletSets.pistolDamage;
        }
        if (currentStyle == NewGunStyles.shotgun)
        {
            bulletsInTheGun = bulletSets.shotgunBulletsInGun;
            bulletsIHave = bulletSets.shotgunBulletsInStock;
            amountOfBulletsPerLoad = bulletSets.shotgunMaxInGun;
            damage = bulletSets.shotgunDamage;
        }
        if (currentStyle == NewGunStyles.sniper)
        {
            bulletsInTheGun = bulletSets.sniperBulletsInGun;
            bulletsIHave = bulletSets.sniperBulletsInStock;
            amountOfBulletsPerLoad = bulletSets.sniperMaxInGun;
            damage = bulletSets.sniperDamage;
        }
    }
}
