using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCheckpoint : MonoBehaviour {

    public GameObject checkpoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<NavmeshTarget>().agent.SetDestination(checkpoint.transform.position);
        }
    }
}
