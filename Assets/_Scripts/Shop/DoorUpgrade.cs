using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorUpgrade : MonoBehaviour {

    public GameObject doorLv1;
    public GameObject doorLv2;
    public GameObject doorLv3;

    public Button doorButton;
    public GameObject doorMax;

    public Text doorText;

    public int doorPrice;
    public int upgradePriceChange;
    public int upgrade = 1;

    private void FixedUpdate()
    {
        doorText.text = "" + doorPrice;
        if(doorPrice > Currency.instance.money || upgrade == 3)
        {
            doorButton.interactable = false;
        }
        else
        {
            doorButton.interactable = true;
        }      
        if(upgrade == 3)
        {
            doorMax.SetActive(true);
        }
        else
        {
            doorMax.SetActive(false);
        }
    }

    public void Upgrade()
    {
        Currency.instance.money -= doorPrice;
        if(upgrade == 1)
        {
            doorLv1.SetActive(false);
            doorLv2.SetActive(true);
        }
        if(upgrade == 2)
        {
            doorLv2.SetActive(false);
            doorLv3.SetActive(true);
        }
        upgrade++;
        doorPrice += 2000;
        gameObject.GetComponent<SuppliesRestore>().doorPrice += upgradePriceChange;
    }
}
