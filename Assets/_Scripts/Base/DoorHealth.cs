using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorHealth : MonoBehaviour {

    public float health;
    public float maxHP;
    public float fillAmount;

    public int doorUpgradeNo;
    public Renderer[] doorRen;
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
            doorHP.enabled = false;
            doorRen = GetComponentsInChildren<Renderer>();
            foreach(Renderer r in doorRen)
            {
                r.enabled = false;
            }
            this.gameObject.layer = 2;
        }
        else
        {
            doorHP.enabled = true;
            doorRen = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in doorRen)
            {
                r.enabled = true;
            }
            this.gameObject.layer = 10;
        }

        if(doorHP.enabled == true)
        {
            fillAmount = health / maxHP;
            doorHP.fillAmount = fillAmount;
        }
	}

    public void Damage(int damage)
    {
        if (GamePhases.instance.gamePhases == Phases.FPS)
        {
            health -= damage;
        }
    }
}
