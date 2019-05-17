using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorHealth : MonoBehaviour {

    public int health;
    public int maxHP;

    public int doorUpgradeNo;
    public Renderer doorRen;
    public Image doorHP;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if(health <= 0)
        {
            health = 0;
            doorRen.enabled = false;
            doorHP.enabled = false;
        }
        else
        {
            doorRen.enabled = true;
            doorHP.enabled = true;
        }

        if(doorHP.enabled == true)
        {
            doorHP.fillAmount = health / maxHP;
        }
	}
}
