using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class References : MonoBehaviour {

    public static References instance;

    public GameObject[] turretInfo;
    public GameObject upgradeAndSell;

    public GameObject trapCam;
    public GameObject camView;
    public GameObject trapMap;

    public GameObject turretChosen = null;

    private void Awake()
    {
        instance = this;
    }

    public void InfoOn()
    {
        for (int i = 0; i < turretInfo.Length; i++)
        {
            turretInfo[i].SetActive(false);
        }
        turretInfo[turretChosen.GetComponent<TurretInfo>().upgradeNumber - 1].SetActive(true);
        upgradeAndSell.SetActive(true);
    }
}
