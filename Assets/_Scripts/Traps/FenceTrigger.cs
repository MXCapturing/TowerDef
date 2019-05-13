using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceTrigger : MonoBehaviour {

    public List<GameObject> enemies = new List<GameObject>();

    private void FixedUpdate()
    {
        for (int i = enemies.Count - 1; i > -1; i--)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
            other.GetComponent<NavmeshTarget>().nextTarget = other.GetComponent<NavmeshTarget>().target;
            other.GetComponent<NavmeshTarget>().target = this.transform.root.gameObject;
            other.GetComponent<NavmeshTarget>().agent.SetDestination(this.transform.root.position);
        }
    }

    public void Retarget()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            this.GetComponent<Collider>().enabled = false;
            enemies[i].GetComponent<Rigidbody>().isKinematic = true;
            enemies[i].GetComponent<NavmeshTarget>().target = enemies[i].GetComponent<NavmeshTarget>().nextTarget;
            enemies[i].GetComponent<NavmeshTarget>().agent.SetDestination(enemies[i].GetComponent<NavmeshTarget>().target.transform.position);
        }
    }
}
