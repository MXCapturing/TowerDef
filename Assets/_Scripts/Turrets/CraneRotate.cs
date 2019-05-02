using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneRotate : MonoBehaviour {

    public TurretTarget turretTarget;

    private void Start()
    {
        turretTarget = this.transform.parent.GetComponent<TurretTarget>();
    }

    // Update is called once per frame
    void Update () {
		if(turretTarget.targets.Count > 0 && GamePhases.instance.gamePhases == Phases.FPS)
        {
            Vector3 targetDir = turretTarget.target.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(targetDir, Vector3.up);
            transform.rotation = rotation;
        }
	}
}
