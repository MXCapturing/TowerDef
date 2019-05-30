using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour {

    public static ShopMenu instance;

    public GameObject shopMenu;
    public GameObject mainShopTop;
    public GameObject[] subMenus;
    public GameObject typeMenu;
    public GameObject mapBack;
    public GameObject mapUI;

    public Image darkPanel;

    public bool mapView;


    private void Awake()
    {
        instance = this;
    }

    public void Turrets()
    {
        //typeMenu.SetActive(false);
        for (int i = 0; i < subMenus.Length; i++)
        {
            subMenus[i].SetActive(false);
        }
        mainShopTop.SetActive(false);
        subMenus[0].SetActive(true);
    }

    public void Traps()
    {
        //typeMenu.SetActive(false);
        for (int i = 0; i < subMenus.Length; i++)
        {
            subMenus[i].SetActive(false);
        }
        mainShopTop.SetActive(false);
        subMenus[2].SetActive(true);
    }

    public void Supplies()
    {
        //typeMenu.SetActive(false);
        for (int i = 0; i < subMenus.Length; i++)
        {
            subMenus[i].SetActive(false);
        }
        mainShopTop.SetActive(false);
        subMenus[3].SetActive(true);
    }

    public void Guns()
    {
        //typeMenu.SetActive(false);
        for (int i = 0; i < subMenus.Length; i++)
        {
            subMenus[i].SetActive(false);
        }
        mainShopTop.SetActive(false);
        subMenus[1].SetActive(true);
    }

    public void Base()
    {
        //typeMenu.SetActive(false);
        for (int i = 0; i < subMenus.Length; i++)
        {
            subMenus[i].SetActive(false);
        }
        mainShopTop.SetActive(false);
        subMenus[4].SetActive(true);
    }

    public void Back()
    {
        for (int i = 0; i < subMenus.Length; i++)
        {
            subMenus[i].SetActive(false);
            //typeMenu.SetActive(true);
        }
        mainShopTop.SetActive(true);
    }

    public void ViewMap()
    {
        for (int i = 0; i < subMenus.Length; i++)
        {
            subMenus[i].SetActive(false);
        }
        mapView = true;
        mapUI.SetActive(true);
        mainShopTop.SetActive(false);
        shopMenu.SetActive(false);
        mapBack.SetActive(true);
    }

    private void FixedUpdate()
    {
        if(mapView == true && Input.GetMouseButtonDown(1))
        {
            mapView = false;
            mapUI.SetActive(false);
            for (int i = 0; i < References.instance.turretInfo.Length; i++)
            {
                References.instance.turretInfo[i].SetActive(false);
            }
            References.instance.upgradeAndSell.SetActive(false);
            shopMenu.SetActive(true);
            mainShopTop.SetActive(true);
            mapBack.SetActive(false);
        }
    }
}
