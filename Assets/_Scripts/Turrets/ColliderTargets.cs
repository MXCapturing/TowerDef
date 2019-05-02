using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTargets : MonoBehaviour {

    private TurretTarget turretTarget;

    private void Start()
    {
        turretTarget = this.transform.parent.GetComponent<TurretTarget>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            turretTarget.targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy" && turretTarget.targets.Contains(other.gameObject))
        {
            turretTarget.targets.Remove(other.gameObject);
            turretTarget.target = null;
        }
    }

}
