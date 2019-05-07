using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDamage : MonoBehaviour {

    public float speed;
    public Vector3 target;

    public float radius;
    public int damage;

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position += Vector3.MoveTowards(transform.position, target, step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Map")
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

                enemy.Damage(damage);
            }
        }
        Destroy(this.gameObject);
    }
}
