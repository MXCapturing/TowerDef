using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInRange : MonoBehaviour {

    public List<GameObject> target = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name.Contains("Fence") || other.tag == "Player" || other.name.Contains("Door"))
        {
            target.Add(other.gameObject);
            this.transform.root.GetComponent<NavmeshTarget>().attacking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Trap" && target.Contains(other.gameObject))
        {
            target.Remove(other.gameObject);
        }
        if(other.tag == "Player" && target.Contains(other.gameObject))
        {
            target.Remove(other.gameObject);
        }
        if(other.name.Contains("Door") && target.Contains(other.gameObject))
        {
            target.Remove(other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < target.Count; i++)
        {
            if(target[i] == null)
            {
                target.RemoveAt(i);
            }
            if(target[i].name.Contains("Door") && target[i].GetComponent<DoorHealth>().doorRen[0].GetComponent<Renderer>().enabled == false)
            {
                target.RemoveAt(i);
            }
        }

        if(target.Count == 0)
        {
            this.transform.root.GetComponent<NavmeshTarget>().attacking = false;
        }
    }
}
