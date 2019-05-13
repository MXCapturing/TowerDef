using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public int damage;
    public float attackDelay;

    public GameObject attackHitbox;
    public Animator _anim;

    public TargetInRange inRange;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Attack", 1f, attackDelay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Attack()
    {
        if(inRange.target.Count > 0)
        {
            int attack = Random.Range(0, 3);
            _anim.SetTrigger("Attack " + attack);
        }
    }

    public void Hitbox()
    {
        attackHitbox.SetActive(true);
    }
}
