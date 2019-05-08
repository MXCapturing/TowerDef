using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour {

    public int hitDamage;
    public float radius;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Invoke("DoDamage", 1f);
            Invoke("Destroy", 1.5f);
        }
    }

    void DoDamage()
    {
        this.GetComponent<Renderer>().enabled = false;
        this.GetComponent<Collider>().enabled = false;
        Collider[] col = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyEnemy in col)
        {
            EnemyHP enemy = nearbyEnemy.GetComponent<EnemyHP>();
            if (enemy != null)
            {
                float proximity = (transform.position - enemy.transform.position).magnitude;
                float effect = 1 - (proximity / radius);

                hitDamage = Mathf.RoundToInt(this.gameObject.GetComponent<TurretInfo>().damage * effect);

                if (hitDamage < 0)
                {
                    hitDamage = 0;
                }

                enemy.Damage(hitDamage);
                Debug.Log(nearbyEnemy);
                Debug.Log(hitDamage);
            }
        }
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
