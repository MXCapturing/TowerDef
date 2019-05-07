using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDamage : MonoBehaviour {

    public float speed;
    public Vector3 target;

    public float radius;
    public int damage;

    private void Start()
    {
        transform.LookAt(target);
    }

    private void Update()
    {
        transform.position += transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" || other.tag == "Map")
        {
            DoDamage();
            this.GetComponent<Renderer>().enabled = false;
            this.GetComponent<Collider>().enabled = false;
        }
    }


    void DoDamage()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyEnemy in col)
        {
            EnemyHP enemy = nearbyEnemy.GetComponent<EnemyHP>();
            if(enemy != null)
            {
                float proximity = (transform.position - enemy.transform.position).magnitude;
                float effect = 1 - (proximity / radius);

                damage = Mathf.RoundToInt(damage * effect);

                if(damage < 0)
                {
                    damage = 0;
                }

                enemy.Damage(damage);
            }
        }
        Destroy(this.gameObject);
    }
}
