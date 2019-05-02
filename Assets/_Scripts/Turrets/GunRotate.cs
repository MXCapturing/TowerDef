using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour {

    public TurretTarget turretTarget;

    public float speed;

    private void Start()
    {
        turretTarget = this.transform.root.GetComponent<TurretTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turretTarget.targets.Count > 0 && GamePhases.instance.gamePhases == Phases.FPS)
        {
            Vector3 targetDir = (turretTarget.target.transform.position - new Vector3(0, 2f, 0)) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(targetDir, Vector3.up);
            transform.rotation = rotation;
        }
    }
}
