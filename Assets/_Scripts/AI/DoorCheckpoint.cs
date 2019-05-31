using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheckpoint : MonoBehaviour {

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;

    public GameObject checkpoint;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.transform.root.GetComponent<NavmeshTarget>().agent.SetDestination(checkpoint.transform.position);
            other.transform.root.GetComponent<NavmeshTarget>().target = checkpoint;

            if (checkpoint.name.Contains("Door") && checkpoint.activeSelf == false)
            {
                other.transform.root.GetComponent<NavmeshTarget>().agent.SetDestination(player.transform.position);
                other.transform.root.GetComponent<NavmeshTarget>().target = player;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
		if(GameObject.Find("Script Holder").GetComponent<DoorUpgrade>().upgrade == 1)
        {
            checkpoint = door1;
        }
        else if (GameObject.Find("Script Holder").GetComponent<DoorUpgrade>().upgrade == 2)
        {
            checkpoint = door2;
        }
        else if (GameObject.Find("Script Holder").GetComponent<DoorUpgrade>().upgrade == 3)
        {
            checkpoint = door3;
        }
    }
}
