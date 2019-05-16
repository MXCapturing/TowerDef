using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class PlayerHP : MonoBehaviour {

    public int health;
    public int maxHP;

    public int armour;
    public int maxArmour;

    public GameObject gameOver;
    public Text waveEnd;

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
            this.gameObject.GetComponent<PlayerMovementScript>().enabled = false;
            this.gameObject.GetComponent<MouseLookScript>().enabled = false;
            Destroy(this.gameObject.GetComponent<GunInventory>().currentGun);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameOver.SetActive(true);
            waveEnd.text = "Wave: " + (EnemyWaves.instance.nextWave + 1f);
            Analytics.CustomEvent("DeathWave", new Dictionary<string, object>
            {
                {"Final Wave", (EnemyWaves.instance.nextWave + 1) },
                {"Money Remaining", (Currency.instance.money) }
            });
            Debug.Log("Dead");
        }
	}
}
