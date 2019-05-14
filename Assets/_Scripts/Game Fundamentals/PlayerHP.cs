using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour {

    public int health;
    public int maxHP;

    public int armour;
    public int maxArmour;

	// Use this for initialization
	void Start () {

	}
	
    public void Damage(int damage)
    {
        if(GamePhases.instance.gamePhases == Phases.FPS)
        {
            if(armour > 0)
            {
                armour--;
            }
            else if(armour == 0)
            {
                health -= damage;
            }

            if(health <= 0)
            {
                health = 0;

            }
        }
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
		if(health <= 0)
        {
            this.gameObject.GetComponent<PlayerMovementScript>().currentSpeed = 0;
            Debug.Log("Dead");
        }
	}
}
