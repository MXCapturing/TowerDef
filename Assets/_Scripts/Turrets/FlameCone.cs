using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCone : MonoBehaviour {

    public Collider damageZone;
    public Renderer render;

     public void DamageOn()
     {
        render.enabled = true;
        damageZone.enabled = true;
        Invoke("DamageOff", 0.5f);
     }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHP>().Damage(this.transform.root.GetComponent<TurretInfo>().damage);
        }
    }

    private void DamageOff()
    {
        render.enabled = false;
        damageZone.enabled = false;
    }
}
