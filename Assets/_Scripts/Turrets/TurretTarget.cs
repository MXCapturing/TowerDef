using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTarget : MonoBehaviour {

    public GameObject target = null;
    public List<GameObject> targets = new List<GameObject>();

    // Use this for initialization

    private void Start()
    {
        InvokeRepeating("TurretFire", 1f, (1 / this.gameObject.GetComponent<TurretInfo>().fireRate));
    }

    private void FixedUpdate()
    {
        for (int i = targets.Count - 1; i > -1; i--)
        {
            if(targets[i] == null)
            {
                targets.RemoveAt(i);
                target = null;
            }
        }
    }
    private void Update()
    {
        if(targets.Count > 0)
        {
            target = targets[0];
        }
    }

    private void TurretFire()
    {
        if (target != null && GamePhases.instance.gamePhases == Phases.FPS)
        {
            Debug.Log("Fire");
            target.gameObject.GetComponent<EnemyHP>().Damage(this.gameObject.GetComponent<TurretInfo>().damage);
        }
    }
}
