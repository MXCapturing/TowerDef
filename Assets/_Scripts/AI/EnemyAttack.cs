using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public int damage;
    public float attackDelay;

    public GameObject attackHitbox;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Attack", 1f, attackDelay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Attack()
    {
        if(this.GetComponent<NavmeshTarget>().target.tag == "Trap")
        {
            attackHitbox.SetActive(true);
        }
    }
}
