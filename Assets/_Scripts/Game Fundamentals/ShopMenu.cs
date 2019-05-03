using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour {

    public static ShopMenu instance;

    public GameObject shopMenu;
    public GameObject[] subMenus;
    public GameObject typeMenu;
    public GameObject mapBack;

    public Image darkPanel;


    private void Awake()
    {
        instance = this;
    }

    public void Turrets()
    {
        typeMenu.SetActive(false);
        subMenus[0].SetActive(true);
    }

    public void Back()
    {
        for (int i = 0; i < subMenus.Length; i++)
        {
            subMenus[i].SetActive(false);
            typeMenu.SetActive(true);
        }
    }

    public void ViewMap()
    {
        shopMenu.SetActive(false);
        mapBack.SetActive(true);
    }

    public void MapBack()
    {
        References.instance.turretInfo.SetActive(false);
        shopMenu.SetActive(true);
        mapBack.SetActive(false);
    }
}
