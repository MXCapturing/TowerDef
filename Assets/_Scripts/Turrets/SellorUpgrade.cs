using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellorUpgrade : MonoBehaviour {

    public GameObject turretInfo;

    public void Cancel()
    {
        turretInfo.SetActive(false);
    }

    public void Sell()
    {
        turretInfo.SetActive(false);
        //Give Player Money
        Destroy(References.instance.turretChosen);
    }
}
