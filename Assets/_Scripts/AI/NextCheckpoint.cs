using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCheckpoint : MonoBehaviour {

    public GameObject checkpoint;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.transform.root.GetComponent<NavmeshTarget>().agent.SetDestination(checkpoint.transform.position);
            other.transform.root.GetComponent<NavmeshTarget>().target = checkpoint;

            if(checkpoint.name.Contains("Door") && checkpoint.activeSelf == false)
            {
                other.transform.root.GetComponent<NavmeshTarget>().agent.SetDestination(player.transform.position);
                other.transform.root.GetComponent<NavmeshTarget>().target = player;
            }
        }
    }
}
