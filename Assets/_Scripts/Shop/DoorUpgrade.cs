using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorUpgrade : MonoBehaviour {

    public List<GameObject> doors = new List<GameObject>();

    public Button doorButton;

    public int doorPrice;
    public int upgradePriceChange;
    public int upgrade = 1;

    public GameObject[] doorLevelUp;

    private void FixedUpdate()
    {
        if(doorPrice > Currency.instance.money || upgrade == 3)
        {
            doorButton.enabled = false;
        }
        else
        {
            doorButton.enabled = true;
        }      
    }

    public void Upgrade()
    {
        Currency.instance.money -= doorPrice;
        for (int i = 0; i < doors.Count; i++)
        {
           GameObject door =  Instantiate(doorLevelUp[upgrade], doors[i].transform.position, doors[i].transform.rotation);
            Destroy(doors[i]);
            doors.Insert(i, door);
        }
        upgrade++;
        gameObject.GetComponent<SuppliesRestore>().doorPrice += upgradePriceChange;
    }
}
