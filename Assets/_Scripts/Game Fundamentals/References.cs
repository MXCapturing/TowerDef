using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class References : MonoBehaviour {

    public static References instance;

    public GameObject turretInfo;

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
        turretInfo.SetActive(true);
    }
}
