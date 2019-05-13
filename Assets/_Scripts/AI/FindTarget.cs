using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTarget : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            this.transform.root.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.transform.root.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            this.transform.root.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.root.GetComponent<NavmeshTarget>().target = other.GetComponent<NavmeshTarget>().target;
            this.transform.root.GetComponent<NavmeshTarget>().agent.SetDestination(this.transform.root.GetComponent<NavmeshTarget>().target.transform.position);
        }
    }
}
