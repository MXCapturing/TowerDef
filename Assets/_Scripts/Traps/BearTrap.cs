using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour {

    public int timer;

    public GameObject enemy;
    public int trappedEnemy = 0;

    public Animator clamp;

    private void Update()
    {
        if(trappedEnemy == 1 && enemy == null)
        {
            Debug.Log("Instant");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && trappedEnemy == 0 && other.GetComponent<NavmeshTarget>().trapped == false)
        {
            enemy = other.gameObject;
            trappedEnemy = 1;
            other.GetComponent<NavmeshTarget>().trapped = true;
            other.GetComponent<NavmeshTarget>().agent.velocity = Vector3.zero;
            other.GetComponent<NavmeshTarget>().agent.isStopped = true;
            other.GetComponent<EnemyHP>().Damage(this.GetComponent<TurretInfo>().damage);
            other.transform.position = this.transform.localPosition;
            clamp.SetBool("Trapped", true);
            Invoke("Destroy", timer);
        }
    }

    void Destroy()
    {
        Debug.Log("Timed");
        enemy.GetComponent<NavmeshTarget>().trapped = false;
        enemy.GetComponent<NavmeshTarget>().agent.isStopped = false;
        Destroy(gameObject);
    }
}
