using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxDamage : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Contains("Fence"))
        {
            other.GetComponent<Fence>().Damage(this.transform.root.GetComponent<EnemyAttack>().damage);
            Invoke("HitboxOff", 0.5f);
        }
    }

    void HitboxOff()
    {
        this.transform.root.GetComponent<EnemyAttack>().attackHitbox.SetActive(false);
    }
}
